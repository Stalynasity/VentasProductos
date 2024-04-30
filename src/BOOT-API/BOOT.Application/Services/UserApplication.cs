using AutoMapper;
using BOOT.Application.Commons;
using BOOT.Application.Dtos.User.Request;
using BOOT.Application.Interfaces;
using BOOT.Domain.Entities;
using BOOT.Infrastructura.Persistences.Interfaces;
using BOOT.Utilities.Static;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace BOOT.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //lib Microsoft.Extensions.Configuration;
        private readonly IConfiguration _configuration;

        public UserApplication(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }


        // se genera el token, a lo que iniciamos sesion pasa por aqui
        public async Task<BaseResponse<string>> GenerateToken(TokenRequestDto requestDto)
        {
            var respone = new BaseResponse<string>();
            var account = await _unitOfWork.User.AccountByUserName(requestDto.email!);

            if (account is not null)
            {
                if (BC.Verify(requestDto.Password, account.Password))
                {
                    respone.IsSuccess = true;
                    respone.Data = GenerateToken(account);
                    respone.Message = ReplyMessage.MESSAGE_TOKEN;
                    return respone;
                }
            }
            else
            {
                respone.IsSuccess = false;
                respone.Message = ReplyMessage.MESSAGE_TOKEN_ERROR;
            }

            return respone;
        }


        // se crea un nuevo usuario
        public async Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var account = _mapper.Map<User>(requestDto);
            account.Password = BC.HashPassword(account.Password);

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


        private string GenerateToken(User user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var clains = new List<Claim>
            {
                //verificar librerias JsonWebTokens no va
                new Claim(JwtRegisteredClaimNames.NameId, user.Email!),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.Email!),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Email!),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, Guid.NewGuid().ToString(), ClaimValueTypes.Integer64)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: clains,
                expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:Expires"])),
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
