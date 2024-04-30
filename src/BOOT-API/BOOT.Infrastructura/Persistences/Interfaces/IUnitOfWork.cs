using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOT.Infrastructura.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Product { get; }
        IUserRepository User { get; }
        void SaveChange();
        Task SaveChangesAsync();

    }
}
