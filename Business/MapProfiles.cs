using AutoMapper;
using Core.Concretes.DTOs.Product;
using Core.Concretes.Entities;

namespace Business
{
    public class MapProfiles : Profile
    {
        public MapProfiles()
        {
            // CreateDto -> Entity
            CreateMap<CreateProductDto, Product>();

            // Entity -> ListDto
            CreateMap<Product, StoreProductListDto>();

            // Entity <-> UpdateDto
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
