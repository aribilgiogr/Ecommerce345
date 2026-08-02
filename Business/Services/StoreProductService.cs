using AutoMapper;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Product;
using Core.Concretes.Entities;
using Core.Concretes.Enums;
using Core.Utils;
using Microsoft.AspNetCore.Identity;

namespace Business.Services
{
    public class StoreProductService : IStoreProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public StoreProductService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<bool> CreateProductAsync(CreateProductDto createProductDto, int storeId)
        {
            var product = mapper.Map<Product>(createProductDto);
            product.StoreId = storeId;
            var repo = unitOfWork.Repository<Product>();
            await repo.CreateOneAsync(product);
            int rows = await unitOfWork.CommitAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteProductAsync(int productId, int storeId)
        {
            var repo = unitOfWork.Repository<Product>();
            var product = await repo.ReadByIdAsync(productId);
            if (product == null || product.StoreId != storeId) return false;
            repo.DeleteOne(productId);
            int rows = await unitOfWork.CommitAsync();
            return rows > 0;
        }

        public async Task<int> GetCurrentStoreIdAsync(string user_id)
        {
            var user = await userManager.FindByIdAsync(user_id);
            if (user != null && user.UserType == UserType.StoreOwner)
            {
                var repo = unitOfWork.Repository<Store>();
                if (await repo.AnyAsync(x => x.AppUserId == user_id))
                {
                    return user.StoreProfile!.Id;
                }
            }
            return 0;
        }

        public async Task<UpdateProductDto?> GetStoreProductForEditAsync(int productId, int storeId)
        {
            var repo = unitOfWork.Repository<Product>();
            var product = await repo.ReadByIdAsync(productId);
            if (product == null || product.StoreId != storeId) return null;

            return mapper.Map<UpdateProductDto>(product);
        }

        public async Task<IEnumerable<StoreProductListDto>> GetStoreProductsAsync(int storeId)
        {
            var repo = unitOfWork.Repository<Product>();
            var products = await repo.ReadManyAsync(x => x.StoreId == storeId);
            return mapper.Map<IEnumerable<StoreProductListDto>>(products);
        }

        public async Task<bool> UpdateProductAsync(UpdateProductDto updateProductDto, int storeId)
        {
            var repo = unitOfWork.Repository<Product>();
            var product = mapper.Map<Product>(updateProductDto);
            product.StoreId = storeId;
            repo.UpdateOne(product);
            int rows = await unitOfWork.CommitAsync();
            return rows > 0;
        }
    }
}
