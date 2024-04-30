using BOOT.Application.Commons.General;
using BOOT.Application.Dtos.User.Request;
using BOOT.Application.Helpers;
using BOOT.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BOOT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestDto requestDto)
        {
            var response = await _userApplication.RegisterUser(requestDto);
            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost("Generate/Token")]
        public async Task<IActionResult> GenerateToken([FromBody] TokenRequestDto requestDto)
        {
            var response = await _userApplication.GenerateToken(requestDto);
            return Ok(response);
        }

        [HttpPost]
        public string Post([FromBody] TestEncryptRequestModel value)
        {
            MethodsEscryptHelper methodsEscryptHelper = new MethodsEscryptHelper();


            if (value.encrypt)
            {
                return methodsEscryptHelper.EncryptPassword(value.value);
            }
            else
            {
                return methodsEscryptHelper.DencryptPassword(value.value);
            }


        }

    }
}
