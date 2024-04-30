using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using BOOT.Application.Commons;
using BOOT.Application.Dtos.User.Request;
using BOOT.Application.Interfaces;
using BOOT.Domain.Entities;
using BOOT.Infrastructura.Persistences.Interfaces;
using BOOT.Utilities.Static;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;
using BOOT.Application.Helpers;
using Newtonsoft.Json.Linq;

namespace BOOT.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserApplication(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<string>> GenerateToken(TokenRequestDto requestDto)
        {
            var TU = await _unitOfWork.User.AccountByUserName(requestDto.email!);

            if (TU != null)
            {

                string passFindDecript = (new MethodsEscryptHelper()).DencryptPassword(TU.Password);
                if (passFindDecript == requestDto.Password)
                {
                    if (TU.Status == "A")
                    {
                        return new BaseResponse<string>
                        {
                            IsSuccess = true,
                            Errors = null,
                            Data = (new MethodsHelper()).CreateTokenSesion(TU.UseId),
                            Message = "Token generado"
                        };
                    }
                    else
                    {
                        return new BaseResponse<string>
                        {
                            IsSuccess = true,
                            Errors = null,
                            Data = null,
                            Message = "Usuario desabilitado"
                        };
                    }
                }
                else
                {
                    return new BaseResponse<string>
                    {
                        Message = "contraseña Incorrecto"
                    };
                }
            }
            else
            {
                return new BaseResponse<string>
                {
                    Message = "Contraseña incorrecta"
                };
            }
        }

        public async Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto)
        {

            var response = new BaseResponse<bool>();
            var account = _mapper.Map<TUser>(requestDto);
            account.Password = (new MethodsEscryptHelper()).EncryptPassword(requestDto.password);
            account.Status = "A";

            response.Data = await _unitOfWork.User.UserRegister(account);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;

        }
    }
}
