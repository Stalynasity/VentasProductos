using BOOT.Domain.Entities;
using BOOT.Infrastructura.Commons;
using BOOT.Infrastructura.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOT.Infrastructura.Persistences.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BootContext _context;

        public ProductRepository(BootContext context)
        {
            _context = context;
        }

        public async Task<BaseEntityResponse<Product>> ListProduct()
        {
            var response = new BaseEntityResponse<Product>();

            var product = (from c in _context.Products
                              select c).Include(x => x.Categorys).AsNoTracking().AsQueryable();


            response.TotalRecords = product.Count();
            response.Items =  await _context.Products.ToListAsync();


            return response;
        }
        
        public async Task<Product> GetIdProduct(int id)
        {
            IQueryable<Product> query = _context.Products;

            var product = query.Include(x => x.Categorys).AsNoTracking().AsQueryable();

            var response = await product.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId.Equals(id));

            return response!;
        }
        
        //public Task<bool> RegisterProduc(Product entity)
        //{
        //    throw new NotImplementedException();
        //}
        
        //public Task<bool> EditProduc(Product entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> RemoveProduc(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
