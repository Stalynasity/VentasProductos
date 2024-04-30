using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOT.Application.Dtos.User.Request
{
    public class TokenRequestDto
    {
        public string? email { get; set; }
        public string? Password { get; set; }
    }
}
