using AutoMapper;
using Shopy.Application.Models;
using Shopy.Domain.Entitties;
using Shopy.Domain.Enums;

namespace Shopy.Application.Mappings
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Size, SizeResponse>();

            CreateMap<Brand, BrandResponse>()
                .ForMember(dst => dst.Label, opt => opt.MapFrom(src => src.Label))
                .ForMember(dst => dst.Code, opt => opt.MapFrom(src => src.Code));

            CreateMap<ProductSize, SizeResponse>()
                .ForMember(dst => dst.Label, opt => opt.MapFrom(src => src.Size.Label))
                .ForMember(dst => dst.Code, opt => opt.MapFrom(src => src.Size.Code));

            CreateMap<ProductCategory, ProductCategoryResponse>()
                .ForMember(dst => dst.ExternalId, opt => opt.MapFrom(src => src.Category.ExternalId))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Product, ProductResponse>()
                .ForMember(dst => dst.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dst => dst.Categories, opt => opt.MapFrom(src => src.Categories))
                .ForMember(dst => dst.Sizes, opt => opt.MapFrom(src => src.Sizes));

            CreateMap<Product, ProductDetailsResponse>()
                .ForMember(dst => dst.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dst => dst.Categories, opt => opt.MapFrom(src => src.Categories))
                .ForMember(dst => dst.Sizes, opt => opt.MapFrom(src => src.Sizes))
                .ForMember(dst => dst.RelatedProducts, opt => opt.MapFrom(src => src.GetRelatedProducts()));

            CreateMap<Product, RelatedProductResponse>()
                .ForMember(dst => dst.Sizes, opt => opt.MapFrom(src => src.Sizes));

            CreateMap<Category, CategoryReponse>();
            CreateMap<Category, ProductCategoryResponse>();
            CreateMap<Category, LookupResponse>();
        }
    }
}
