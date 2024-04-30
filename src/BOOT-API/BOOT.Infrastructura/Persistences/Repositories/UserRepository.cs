using BOOT.Domain.Entities;
using BOOT.Infrastructura.Persistences.Contexts;
using BOOT.Infrastructura.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOT.Infrastructura.Persistences.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbproductContext _context;

        public UserRepository(DbproductContext context)
        {
            _context = context;
        }

        public async Task<TUser> AccountByUserName(string UseName)
        {
            var account = await _context.TUsers.AsNoTracking().FirstOrDefaultAsync(x => x.UseName.Equals(UseName));
            return account!;
        }

        public async Task<bool> UserRegister(TUser entity)
        {
            await _context.TUsers.AddAsync(entity);

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }
    }
}
