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
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<CreateBrandDto, Brand>();

            // Entity -> ListDto
            CreateMap<Product, StoreProductListDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt ?? src.CreatedAt))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Category, CategoryListDto>();
            CreateMap<Brand, BrandListDto>();

            CreateMap<ProductImage, ProductImageDto>();
            CreateMap<ProductFeature, ProductFeatureDto>();

            // Entity <-> UpdateDto
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();

            // Entity -> DetailDto
            CreateMap<Product, StoreProductDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
