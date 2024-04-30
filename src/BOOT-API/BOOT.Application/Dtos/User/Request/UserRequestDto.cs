using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOT.Application.Dtos.User.Request
{
    public class UserRequestDto
    {
        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? IdentityCard { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Direccion { get; set; }

        public string? Phone { get; set; }

        public int? State { get; set; }
    }
}
