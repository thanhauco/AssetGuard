using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Interfaces
{
    public interface ITagGenerationService
    {
        Task<TagOutputDto> GenerateTagAsync(GenerateTagDto dto);
        Task<IEnumerable<TagOutputDto>> GenerateBatchTagsAsync(IEnumerable<int> assetIds, int? templateId);
        
        Task<LabelTemplate> CreateTemplateAsync(LabelTemplateDto dto);
        Task<LabelTemplate> GetTemplateByIdAsync(int id);
        Task<IEnumerable<LabelTemplate>> GetAllTemplatesAsync();
        Task<LabelTemplate> GetDefaultTemplateAsync();
        Task SetDefaultTemplateAsync(int templateId);
    }
}
