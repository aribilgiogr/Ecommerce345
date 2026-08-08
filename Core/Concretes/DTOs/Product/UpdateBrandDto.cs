namespace Core.Concretes.DTOs.Product
{
    public class UpdateBrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? LogoUrl { get; set; }
    }
}
