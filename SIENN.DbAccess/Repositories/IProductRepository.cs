using SIENN.DbAccess.Data;
using System;
using System.Collections.Generic;

namespace SIENN.DbAccess.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetAvailableProducts(int skip, int take);
        IEnumerable<Product> GetFilteredProducts(FieldType fieldType, string value);
        IEnumerable<Product> GetProductInfo(string code);
        void Save();
    }
}
