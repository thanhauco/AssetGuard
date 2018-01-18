using System;
using System.Collections.Generic;

namespace AssetGuard.Core.Entities
{
    public class ApplicationUser : BaseEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
