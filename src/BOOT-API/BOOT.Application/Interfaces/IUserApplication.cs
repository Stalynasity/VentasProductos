using BOOT.Application.Commons;
using BOOT.Application.Dtos.User.Request;

namespace BOOT.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto);
        Task<BaseResponse<string>> GenerateToken(TokenRequestDto requestDto);
    }
}
