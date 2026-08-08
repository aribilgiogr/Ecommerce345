namespace Core.Concretes.DTOs.Product
{
    public class CategoryListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DisplayOrder { get; set; }
        public IEnumerable<string> ParentCategories { get; set; } = [];
    }
}
