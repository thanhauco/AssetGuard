namespace AssetGuard.Core.Entities
{
    public class ReportDefinition : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string QueryJson { get; set; } // Serialized query configuration
        public ReportType Type { get; set; }
    }

    public enum ReportType
    {
        Table,
        Chart,
        Summary
    }
}
