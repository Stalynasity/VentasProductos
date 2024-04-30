using BOOT.Domain.Entities;
using BOOT.Infrastructura.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOT.Infrastructura.Persistences.Interfaces
{
    public interface IProductRepository
    {
        Task<BaseEntityResponse<Product>> ListProduct();
        Task<Product> GetIdProduct(int id);
        //Task<bool> RegisterProduc(Product entity);
        //Task<bool> EditProduc(Product entity);
        //Task<bool> RemoveProduc(int id);
    }
}
