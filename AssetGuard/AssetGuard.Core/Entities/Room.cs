namespace AssetGuard.Core.Entities
{
    public class Room : BaseEntity
    {
        public string Number { get; set; }
        public string Floor { get; set; }
        public int Capacity { get; set; }
        
        public int BuildingId { get; set; }
        public virtual Building Building { get; set; }
    }
}
