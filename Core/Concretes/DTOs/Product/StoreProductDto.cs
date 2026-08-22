namespace Core.Concretes.DTOs.Product
{
    public class StoreProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string SKU { get; set; } = null!;
        public int StoreId { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public IEnumerable<ProductImageDto> Images { get; set; } = [];
        public IEnumerable<ProductFeatureDto> Features { get; set; } = [];
    }
}
