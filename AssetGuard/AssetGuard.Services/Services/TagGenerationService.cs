using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class TagGenerationService : ITagGenerationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagGenerationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TagOutputDto> GenerateTagAsync(GenerateTagDto dto)
        {
            var asset = await _unitOfWork.Repository<Asset>().GetByIdAsync(dto.AssetId);
            var template = dto.TemplateId.HasValue
                ? await GetTemplateByIdAsync(dto.TemplateId.Value)
                : await GetDefaultTemplateAsync();

            var barcodeData = GenerateBarcodeData(asset);
            var qrData = GenerateQrCodeData(asset);
            var html = GenerateHtml(asset, template, barcodeData, qrData);

            return new TagOutputDto
            {
                AssetId = asset.Id,
                AssetName = asset.Name,
                SerialNumber = asset.SerialNumber,
                BarcodeData = barcodeData,
                QrCodeData = qrData,
                HtmlContent = html
            };
        }

        public async Task<IEnumerable<TagOutputDto>> GenerateBatchTagsAsync(IEnumerable<int> assetIds, int? templateId)
        {
            var results = new List<TagOutputDto>();
            foreach (var id in assetIds)
            {
                var tag = await GenerateTagAsync(new GenerateTagDto { AssetId = id, TemplateId = templateId });
                results.Add(tag);
            }
            return results;
        }

        public async Task<LabelTemplate> CreateTemplateAsync(LabelTemplateDto dto)
        {
            var template = new LabelTemplate
            {
                Name = dto.Name,
                Size = Enum.Parse<LabelSize>(dto.Size),
                IncludeQrCode = dto.IncludeQrCode,
                IncludeBarcode = dto.IncludeBarcode,
                IncludeAssetName = dto.IncludeAssetName,
                IncludeSerialNumber = dto.IncludeSerialNumber,
                IsDefault = dto.IsDefault
            };

            await _unitOfWork.Repository<LabelTemplate>().AddAsync(template);
            await _unitOfWork.CompleteAsync();
            return template;
        }

        public async Task<LabelTemplate> GetTemplateByIdAsync(int id)
        {
            return await _unitOfWork.Repository<LabelTemplate>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<LabelTemplate>> GetAllTemplatesAsync()
        {
            return await _unitOfWork.Repository<LabelTemplate>().GetAllAsync();
        }

        public async Task<LabelTemplate> GetDefaultTemplateAsync()
        {
            var all = await GetAllTemplatesAsync();
            return all.FirstOrDefault(t => t.IsDefault) ?? all.FirstOrDefault();
        }

        public async Task SetDefaultTemplateAsync(int templateId)
        {
            var all = await GetAllTemplatesAsync();
            foreach (var t in all)
            {
                t.IsDefault = t.Id == templateId;
            }
            await _unitOfWork.CompleteAsync();
        }

        private string GenerateBarcodeData(Asset asset)
        {
            return $"AG-{asset.Id:D6}";
        }

        private string GenerateQrCodeData(Asset asset)
        {
            return $"ASSET|ID:{asset.Id}|SN:{asset.SerialNumber}|NAME:{asset.Name}";
        }

        private string GenerateHtml(Asset asset, LabelTemplate template, string barcode, string qr)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<div class='asset-tag'>");
            
            if (template?.IncludeAssetName == true)
                sb.AppendLine($"<div class='asset-name'>{asset.Name}</div>");
            
            if (template?.IncludeSerialNumber == true)
                sb.AppendLine($"<div class='serial-number'>SN: {asset.SerialNumber}</div>");
            
            if (template?.IncludeBarcode == true)
                sb.AppendLine($"<div class='barcode' data-value='{barcode}'>{barcode}</div>");
            
            if (template?.IncludeQrCode == true)
                sb.AppendLine($"<div class='qrcode' data-value='{qr}'>[QR]</div>");
            
            sb.AppendLine("</div>");
            return sb.ToString();
        }
    }
}
