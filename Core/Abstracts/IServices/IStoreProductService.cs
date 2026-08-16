using Core.Concretes.DTOs.Product;

namespace Core.Abstracts.IServices
{
    public interface IStoreProductService
    {
        Task<int> GetCurrentStoreIdAsync(string user_id);
        Task<IEnumerable<StoreProductListDto>> GetStoreProductsAsync(int storeId);
        Task<bool> CreateProductAsync(CreateProductDto createProductDto, int storeId);
        Task<bool> UpdateProductAsync(UpdateProductDto updateProductDto, int storeId);
        Task<bool> DeleteProductAsync(int productId, int storeId);
        Task<UpdateProductDto?> GetStoreProductForEditAsync(int productId, int storeId);
        Task<StoreProductDto?> GetStoreProductAsync(int productId);
    }
}
