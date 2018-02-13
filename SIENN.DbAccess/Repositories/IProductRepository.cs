using SIENN.DbAccess.Data;
using System.Collections.Generic;

namespace SIENN.DbAccess.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetAvailableProducts(int skip, int take);
        IEnumerable<Product> GetFilteredProducts(string type, string category, string unit);
        Product GetProductInfo(string code);
        string Save();
    }
}
