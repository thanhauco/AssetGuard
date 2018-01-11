namespace AssetGuard.Core.Entities
{
    public class DashboardWidget : BaseEntity
    {
        public string Title { get; set; }
        public string WidgetType { get; set; } // "BarChart", "PieChart", "KpiCard"
        public string DataSource { get; set; } // API Endpoint or Query
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
