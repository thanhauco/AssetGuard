using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface ICustomFieldService
    {
        Task<CustomField> CreateFieldAsync(CustomField field);
        Task<CustomField> GetFieldByIdAsync(int id);
        Task<IEnumerable<CustomField>> GetFieldsForCategoryAsync(int? categoryId);
        Task UpdateFieldAsync(CustomField field);
        Task DeleteFieldAsync(int fieldId);
        
        Task<CustomFieldValue> SetFieldValueAsync(int assetId, int fieldId, string value);
        Task<IEnumerable<CustomFieldValue>> GetValuesForAssetAsync(int assetId);
        Task<string> GetFieldValueAsync(int assetId, int fieldId);
    }
}
