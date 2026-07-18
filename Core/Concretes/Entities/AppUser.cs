using Core.Concretes.Enums;
using Microsoft.AspNetCore.Identity;

namespace Core.Concretes.Entities
{
    public class AppUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool Active { get; set; } = true;
        public bool Deleted { get; set; } = false;
        public UserType UserType { get; set; }

        public virtual Admin? AdminProfile { get; set; }
        public virtual Customer? CustomerProfile { get; set; }
        public virtual Store? StoreProfile { get; set; }
    }
}
