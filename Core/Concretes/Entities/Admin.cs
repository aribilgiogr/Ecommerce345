using Core.Abstracts.Bases;

namespace Core.Concretes.Entities
{
    public class Admin : BaseEntity
    {
        public string AppUserId { get; set; } = null!;
        public virtual AppUser AppUser { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
