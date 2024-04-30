using BOOT.Domain.Entities;
using BOOT.Infrastructura.Commons;
using BOOT.Infrastructura.Persistences.Contexts;

namespace BOOT.Infrastructura.Persistences.Interfaces
{
    public interface IProductRepository
    {
        Task<BaseEntityResponse<Product>> ListProduct();
        Task<Product> GetIdProduct(int id);
        List<Product> GetAllIdProducts(DbproductContext context, List<int> Ids);
        //Product GetById(int id);
    }
}
