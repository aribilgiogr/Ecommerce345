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
            CreateMap<Product, StoreProductListDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt ?? src.CreatedAt))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            // Entity <-> UpdateDto
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
