using AutoMapper;
using BOOT.Application.Commons;
using BOOT.Application.Commons.General;
using BOOT.Application.Dtos.Product.Response;
using BOOT.Application.Interfaces;
using BOOT.Domain.Entities;
using BOOT.Infrastructura.Commons;
using BOOT.Infrastructura.Persistences.Interfaces;
using BOOT.Utilities.Static;

namespace BOOT.Application.Services
{
    public class ProductApplication : IProductApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BaseResponse<BaseEntityResponse<ProductResponseDto>>> ListProduct()
        {
            var response = new BaseResponse<BaseEntityResponse<ProductResponseDto>>();

            var product = await _unitOfWork.Product.ListProduct();

            if (product is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<ProductResponseDto>>(product);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<ProductResponseDto>> ProductById(int ProductId)
        {
            var response = new BaseResponse<ProductResponseDto>();
            var Product = await _unitOfWork.Product.GetIdProduct(ProductId);

            if (Product is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<ProductResponseDto>(Product);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }
        
        
        public GenericResponse<List<Product>> GetAllIdProducts(List<int> Ids)
        {
            throw new NotImplementedException();
        }
    }
}
