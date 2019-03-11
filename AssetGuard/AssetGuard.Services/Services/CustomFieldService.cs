using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class CustomFieldService : ICustomFieldService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomFieldService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomField> CreateFieldAsync(CustomField field)
        {
            await _unitOfWork.Repository<CustomField>().AddAsync(field);
            await _unitOfWork.CompleteAsync();
            return field;
        }

        public async Task<CustomField> GetFieldByIdAsync(int id)
        {
            return await _unitOfWork.Repository<CustomField>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<CustomField>> GetFieldsForCategoryAsync(int? categoryId)
        {
            var all = await _unitOfWork.Repository<CustomField>().GetAllAsync();
            return all.Where(f => f.CategoryId == categoryId || f.CategoryId == null)
                      .Where(f => f.IsActive)
                      .OrderBy(f => f.DisplayOrder);
        }

        public async Task UpdateFieldAsync(CustomField field)
        {
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteFieldAsync(int fieldId)
        {
            var field = await GetFieldByIdAsync(fieldId);
            field.IsActive = false;
            await _unitOfWork.CompleteAsync();
        }

        public async Task<CustomFieldValue> SetFieldValueAsync(int assetId, int fieldId, string value)
        {
            var values = await _unitOfWork.Repository<CustomFieldValue>().GetAllAsync();
            var existing = values.FirstOrDefault(v => v.AssetId == assetId && v.CustomFieldId == fieldId);

            if (existing != null)
            {
                existing.Value = value;
            }
            else
            {
                existing = new CustomFieldValue
                {
                    AssetId = assetId,
                    CustomFieldId = fieldId,
                    Value = value
                };
                await _unitOfWork.Repository<CustomFieldValue>().AddAsync(existing);
            }

            await _unitOfWork.CompleteAsync();
            return existing;
        }

        public async Task<IEnumerable<CustomFieldValue>> GetValuesForAssetAsync(int assetId)
        {
            var all = await _unitOfWork.Repository<CustomFieldValue>().GetAllAsync();
            return all.Where(v => v.AssetId == assetId);
        }

        public async Task<string> GetFieldValueAsync(int assetId, int fieldId)
        {
            var values = await GetValuesForAssetAsync(assetId);
            return values.FirstOrDefault(v => v.CustomFieldId == fieldId)?.Value;
        }
    }
}
