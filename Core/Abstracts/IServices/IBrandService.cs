using Core.Concretes.DTOs.Product;

namespace Core.Abstracts.IServices
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandListDto>> GetBrandsAsync();
        Task<bool> CreateBrandAsync(CreateBrandDto createBrandDto);
        Task<bool> UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task<bool> DeleteBrandAsync(int brandId);
    }
}
