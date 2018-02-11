using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Data;
using System.Linq;
using System.Collections.Generic;

namespace SIENN.DbAccess.Repositories
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        DbSet<Product> _products;
        public ProductRepository(StoreContext context)
            : base(context)
        {
            _products = context.Products;
        }
        
        public IEnumerable<Product> GetAvailableProducts(int skip, int take)
        {
            var available = GetRange(skip, take, x => x.IsAvailable == true).ToList();   
            return available;
        }

        public IEnumerable<Product> GetFilteredProducts(FieldType fieldType, string value)
        {
            var filtered = _entities.Include(x =>x.Type).Where(x => x.Type.Description.Contains(value)).ToList();
            return filtered;
        }

        public IEnumerable<Product> GetProductInfo(string code)
        {
            var filtered = _entities.Include(x => x.Type).Include(x => x.ProductCategory).ThenInclude(e => e.Category).
                Where(x => x.Description.Contains(code)).ToList();
            return filtered;
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
