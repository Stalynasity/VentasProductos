using BOOT.Domain.Entities;
using BOOT.Infrastructura.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOT.Infrastructura.Persistences.Repositories
{
    public class UnitOfwork : IUnitOfWork
    {
        public IProductRepository Product { get; private set; }
        public IUserRepository User { get; private set; }

        private readonly BootContext _context;

        public UnitOfwork(BootContext context)
        {
            _context = context;
            Product = new ProductRepository(_context);
            User = new UserRepository(_context);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
