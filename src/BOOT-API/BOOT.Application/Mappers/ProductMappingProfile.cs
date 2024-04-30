using AutoMapper;
using BOOT.Application.Dtos.Product.Response;
using BOOT.Domain.Entities;
using BOOT.Infrastructura.Commons;

namespace BOOT.Application.Mappers
{
    public class ProductMappingProfile: Profile
    {
        public ProductMappingProfile() 
        {
            CreateMap<BaseEntityResponse<Product>, BaseEntityResponse<ProductResponseDto>>()
                .ReverseMap();

            CreateMap<Product, ProductResponseDto>()
                .ForMember(x => x.typoCategory, x=> x.MapFrom(y => y.Category.Name))
                .ReverseMap();


            CreateMap<BaseEntityResponse<ProductResponseDto>, BaseEntityResponse<Product>>();
        }
    }
}
