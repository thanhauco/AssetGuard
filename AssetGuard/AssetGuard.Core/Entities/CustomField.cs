using System;

namespace AssetGuard.Core.Entities
{
    public class CustomField : BaseEntity
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }  // Text, Number, Date, Boolean, Dropdown
        public string DropdownOptions { get; set; }  // JSON array for dropdown
        public bool IsRequired { get; set; } = false;
        public int? CategoryId { get; set; }  // null = applies to all
        public Category Category { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class CustomFieldValue : BaseEntity
    {
        public int CustomFieldId { get; set; }
        public CustomField CustomField { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public string Value { get; set; }
    }
}
