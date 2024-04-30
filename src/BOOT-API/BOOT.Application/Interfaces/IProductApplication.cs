using BOOT.Application.Commons;
using BOOT.Application.Commons.General;
using BOOT.Application.Dtos.Product.Response;
using BOOT.Domain.Entities;
using BOOT.Infrastructura.Commons;

namespace BOOT.Application.Interfaces
{
    public interface IProductApplication
    {
        Task<BaseResponse<BaseEntityResponse<ProductResponseDto>>> ListProduct();
        Task<BaseResponse<ProductResponseDto>> ProductById(int ProductId);
        GenericResponse<List<Product>> GetAllIdProducts(List<int> Ids);
    }
}
