using System.Collections.Generic;

namespace AssetGuard.Services.DTOs
{
    public class SiteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullAddress { get; set; }
        public int BuildingCount { get; set; }
    }
}
