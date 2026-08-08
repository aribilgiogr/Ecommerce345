using AutoMapper;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Product;
using Core.Concretes.Entities;
using Core.Utils;

namespace Business.Services
{
    public class BrandService(IUnitOfWork unitOfWork, IMapper mapper) : IBrandService
    {
        public async Task<bool> CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var repo = unitOfWork.Repository<Brand>();
            var brand = mapper.Map<Brand>(createBrandDto);
            await repo.CreateOneAsync(brand);
            int rows = await unitOfWork.CommitAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteBrandAsync(int brandId)
        {
            var repo = unitOfWork.Repository<Brand>();
            if(await repo.AnyAsync(x=>x.Id == brandId))
            {
                repo.DeleteOne(brandId);
                int rows = await unitOfWork.CommitAsync();
                return rows > 0;
            }
            return false;
        }

        public async Task<IEnumerable<BrandListDto>> GetBrandsAsync()
        {
            var repo = unitOfWork.Repository<Brand>();
            var brands = await repo.ReadManyAsync();
            return mapper.Map<IEnumerable<BrandListDto>>(brands);
        }

        public async Task<bool> UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var repo = unitOfWork.Repository<Brand>();
            if (await repo.AnyAsync(x => x.Id == updateBrandDto.Id))
            {
                var brand = mapper.Map<Brand>(updateBrandDto);
                repo.UpdateOne(brand);
                int rows = await unitOfWork.CommitAsync();
                return rows > 0;
            }
            return false;
        }
    }
}
