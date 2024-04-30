using AutoMapper;
using BOOT.Application.Dtos.Product.Response;
using BOOT.Domain.Entities;
using BOOT.Infrastructura.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOT.Application.Mappers
{
    public class ProductMappingProfile: Profile
    {
        public ProductMappingProfile() 
        {
            CreateMap<BaseEntityResponse<Product>, BaseEntityResponse<ProductResponseDto>>()
                .ReverseMap();

            CreateMap<Product, ProductResponseDto>()
                .ReverseMap();

            CreateMap<BaseEntityResponse<Product>, BaseEntityResponse<ProductResponseDto>>()
                .ReverseMap();

            //CreateMap<Product, ProductResponseDto>();
        }
    }
}
