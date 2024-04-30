using BOOT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOT.Infrastructura.Persistences.Interfaces
{
    public interface IUserRepository
    {
        Task<TUser> AccountByUserName(string userName);
        Task<bool> UserRegister(TUser entity);
    }
}
