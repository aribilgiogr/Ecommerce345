using Core.Abstracts.Bases;

namespace Core.Concretes.Entities
{
    public class ProductImage : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int DisplayOrder { get; set; }
    }
}
