
using BOOT.Application.Commons;
using BOOT.Application.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace BOOT.Api.Filters
{
    public class SessionUsuarioFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next
        )
        {
            MethodsHelper MethodsHep = new MethodsHelper();
            var AuthorizationH = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (AuthorizationH != null)
            {
                var MessageError = MethodsHep.ValidateTokenSesion(AuthorizationH);
                if (MessageError == null)
                {
                    await next();
                }
                else
                {
                    context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(new BaseResponse<dynamic>
                    {
                        Message = "Incorrecto",
                    }));
                }
            }
            else
            {
                context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(new BaseResponse<dynamic>
                {
                    Message = "Incorrecto",
                }));
            }

        }
    }
}