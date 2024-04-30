using BOOT.Domain.Entities;
using BOOT.Infrastructura.Commons;
using BOOT.Infrastructura.Commons.Invoice;
using BOOT.Infrastructura.Persistences.Contexts;
using BOOT.Infrastructura.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BOOT.Infrastructura.Persistences.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbproductContext _context;

        public ProductRepository(DbproductContext context)
        {
            _context = context;
        }

        public async Task<BaseEntityResponse<Product>> ListProduct()
        {
            var response = new BaseEntityResponse<Product>();

            IQueryable<Product> query = _context.Products;
            var product = query.Include(x => x.Category).AsNoTracking().AsQueryable();


            response.TotalRecords = product.Count();
            response.Items =  await _context.Products.AsNoTracking().ToListAsync();


            return response;
        }

        public async Task<Product> GetIdProduct(int id)
        {
            IQueryable<Product> query = _context.Products;
            var product = query.Include(x => x.Category).AsNoTracking().AsQueryable();

            var response = await product.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId.Equals(id));
            return response!;
        }


        public void UpdateProductsCount(DbproductContext context, List<Product> ListProd, List<CreateInvoiceModal> ListProdUpdate)
        {
            foreach (Product Prd in ListProd)
            {
                Prd.Count = ListProdUpdate.Single(x => x.ProductId == Prd.ProductId).Count;
            }
            context.SaveChanges();
        }


        public List<Product> GetAllIdProducts(DbproductContext context, List<int> Ids)
        {
            return _context.Products.Where(x=> Ids.Contains(x.ProductId)).ToList();
        }
    }
}
