using Core.Concretes.DTOs.Product;

namespace Core.Abstracts.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListDto>> GetCategoriesAsync();
        Task<bool> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<bool> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<bool> DeleteCategoryAsync(int categoryId);
        Task<UpdateCategoryDto?> GetCategoryByIdAsync(int categoryId);
    }
}
