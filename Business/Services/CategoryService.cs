using AutoMapper;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Product;
using Core.Concretes.Entities;
using Core.Utils;

namespace Business.Services
{
    public class CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : ICategoryService
    {
        public async Task<bool> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var repo = unitOfWork.Repository<Category>();
            var category = mapper.Map<Category>(createCategoryDto);
            await repo.CreateOneAsync(category);
            int rows = await unitOfWork.CommitAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var repo = unitOfWork.Repository<Category>();
            if (await repo.AnyAsync(x => x.Id == categoryId))
            {
                repo.DeleteOne(categoryId);
                int rows = await unitOfWork.CommitAsync();
                return rows > 0;
            }
            return false;
        }

        public async Task<IEnumerable<CategoryListDto>> GetCategoriesAsync()
        {
            var repo = unitOfWork.Repository<Category>();
            var categories = await repo.ReadManyAsync();
            return mapper.Map<IEnumerable<CategoryListDto>>(categories);
        }

        public async Task<UpdateCategoryDto?> GetCategoryByIdAsync(int categoryId)
        {
            var repo = unitOfWork.Repository<Category>();
            var category = await repo.ReadByIdAsync(categoryId);
            return category == null ? null : mapper.Map<UpdateCategoryDto>(category);
        }

        public async Task<bool> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var repo = unitOfWork.Repository<Category>();
            if (await repo.AnyAsync(x => x.Id == updateCategoryDto.Id))
            {
                var category = mapper.Map<Category>(updateCategoryDto);
                repo.UpdateOne(category);
                int rows = await unitOfWork.CommitAsync();
                return rows > 0;
            }
            return false;
        }
    }
}
