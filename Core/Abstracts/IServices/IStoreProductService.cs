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

        Task<IEnumerable<ProductImageDto>> GetProductImagesAsync(int productId);
        Task<bool> AddProductImageAsync(int storeId, int productId, CreateProductImageDto model, string wwwroot);
        Task<bool> DeleteProductImageAsync(int storeId, int productId, int imageId);
        Task<bool> UpdateProductImageDisplayOrderAsync(int storeId, int productId, Dictionary<int, int> imageOrders);

        Task<IEnumerable<ProductFeatureDto>> GetProductFeaturesAsync(int productId);
        Task<bool> AddProductFeatureAsync(int storeId, int productId, CreateProductFeatureDto model);
        Task<bool> DeleteProductFeatureAsync(int storeId, int productId, int featureId);
        Task<bool> UpdateProductFeatureDisplayOrderAsync(int storeId, int productId, Dictionary<int, int> featureOrders);
    }
}
