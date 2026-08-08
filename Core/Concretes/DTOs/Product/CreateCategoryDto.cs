namespace Core.Concretes.DTOs.Product
{
    public class CreateCategoryDto
    {
        public string Name { get; set; } = null!;
        public int DisplayOrder { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
