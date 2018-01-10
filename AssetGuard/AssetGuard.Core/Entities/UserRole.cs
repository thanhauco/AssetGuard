namespace AssetGuard.Core.Entities
{
    public class UserRole
    {
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        
        public int RoleId { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
