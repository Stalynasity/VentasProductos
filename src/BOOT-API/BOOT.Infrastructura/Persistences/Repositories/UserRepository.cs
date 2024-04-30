using BOOT.Domain.Entities;
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
        private readonly BootContext _context;

        public UserRepository(BootContext context)
        {
            _context = context;
        }

        public async Task<User> AccountByUserName(string userName)
        {
            var account = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email!.Equals(userName));
            return account!;
        }

        public async Task<bool> UserRegister(User entity)
        {
            await _context.Users.AddAsync(entity);

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }
    }
}
