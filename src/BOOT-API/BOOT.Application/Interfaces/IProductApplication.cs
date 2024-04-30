using BOOT.Application.Commons;
using BOOT.Application.Dtos.Product.Response;
using BOOT.Infrastructura.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOT.Application.Interfaces
{
    public interface IProductApplication
    {
        Task<BaseResponse<BaseEntityResponse<ProductResponseDto>>> ListProduct();
        Task<BaseResponse<ProductResponseDto>> ProductById(int ProductId);
    }
}
