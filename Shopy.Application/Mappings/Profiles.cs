using AutoMapper;
using Shopy.Application.Models;
using Shopy.Domain.Entitties;

namespace Shopy.Application.Mappings
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Size, SizeResponse>();
            CreateMap<Brand, BrandResponse>();

            CreateMap<ProductSize, SizeResponse>()
                .ForMember(dst => dst.ExternalId, opt => opt.MapFrom(src => src.ExternalId))
                .ForMember(dst => dst.Code, opt => opt.MapFrom(src => src.Size.Code));

            CreateMap<ProductCategory, ProductCategoryResponse>()
                .ForMember(dst => dst.ExternalId, opt => opt.MapFrom(src => src.Category.ExternalId))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Product, ProductResponse>()
                .ForMember(dst => dst.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dst => dst.Categories, opt => opt.MapFrom(src => src.ProductCategories))
                .ForMember(dst => dst.Sizes, opt => opt.MapFrom(src => src.ProductSizes));

            CreateMap<Product, ProductDetailsResponse>()
                .ForMember(dst => dst.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dst => dst.Categories, opt => opt.MapFrom(src => src.ProductCategories))
                .ForMember(dst => dst.Sizes, opt => opt.MapFrom(src => src.ProductSizes));

            CreateMap<Product, RelatedProductResponse>()
                .ForMember(dst => dst.Sizes, opt => opt.MapFrom(src => src.ProductSizes));

            CreateMap<Category, CategoryReponse>();
            CreateMap<Category, ProductCategoryResponse>();
            CreateMap<Category, LookupResponse>();
        }
    }
}
