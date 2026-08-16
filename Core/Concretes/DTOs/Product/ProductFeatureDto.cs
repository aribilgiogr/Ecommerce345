namespace Core.Concretes.DTOs.Product
{
    public class ProductFeatureDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
        public int DisplayOrder { get; set; }
    }
}
