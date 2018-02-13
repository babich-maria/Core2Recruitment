using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Data;
using System.Linq;
using System.Collections.Generic;
using System;

namespace SIENN.DbAccess.Repositories
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {       
        public ProductRepository(StoreContext context)
            : base(context)
        {   }
        
        public IEnumerable<Product> GetAvailableProducts(int skip, int take)
        {
            var available = take > 0 ? GetRange(skip, take, x => x.IsAvailable == true) : new List<Product>();
            return available;
        }

        public IEnumerable<Product> GetFilteredProducts(string type, string category, string unit)
        {           
            //TODO optimize it, could be slow on real data
            var filtered = _entities.Include(x => x.Type).Include(x => x.Unit).Include(x => x.ProductCategory).ThenInclude(x => x.Category).
                Where(x => (x.Type.Description.Contains(type) && x.Unit.Description.Contains(unit) 
                            && x.ProductCategory.Any(i => i.Category.Description.Contains(category)))).ToList();
            return filtered;
        }

        public Product GetProductInfo(string code)
        {           
            return _entities.Include(x => x.Type).Include(x => x.Unit).Include(x => x.ProductCategory).ThenInclude(e => e.Category)
                    .FirstOrDefault(x => x.Code.Contains(code));
        }

        public string Save()
        {
            var result = "Product is added";
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                result = ex.InnerException?.Message;
            }

            return result;
        }
    }
}
