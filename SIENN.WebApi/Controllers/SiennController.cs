using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Data;
using SIENN.DbAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SiennController : Controller
    {
        private readonly IProductRepository _productRepository;
        public SiennController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("api/Get")]
        public string Get()
        {
            return "SIENN Poland";
        }

        [HttpGet]
        [Route("api/GetAvailableProducts")]
        public string GetAvailableProducts(int skip, int take)
        {
            var available = _productRepository.GetAvailableProducts(skip, take);

            StringBuilder str = new StringBuilder(string.Empty);
            foreach (var item in available)
            {
                str.AppendLine($"{item.Code}   {item.Description}");
            }

            return str.ToString();
        }

        [HttpGet]
        [Route("api/GetFilteredProducts")]
        public string GetFilteredProducts(string type = "", string category = "", string unit = "")
        {
            var available = _productRepository.GetFilteredProducts(type.Trim(), category.Trim(), unit.Trim());     
            //TODO  create service to incapsulate this logic
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Description      Type      Unit      Price      Caterories");
            str.AppendLine($"---------------------------------------------------------------------");
            foreach (var item in available)
            {
                str.AppendLine($"{item.Description}   {item.Type.Description}    {item.Unit.Description}     {item.Price}     {item.ProductCategory.Select(x=>x.Category.Description).Aggregate((a, b) => a + ", " + b)} ");
            }

            return str.ToString();
        }

        [HttpGet]
        [Route("api/GetProductInfo")]
        public string GetProductInfo(string code)
        {
            //TODO check null
            var p = _productRepository.GetProductInfo(code);

            StringBuilder str = new StringBuilder(string.Empty);
            str.AppendLine($"Description      Type      Unit      Price      Caterories");
            str.AppendLine($"---------------------------------------------------------------------");
            str.AppendLine($"{p.Description}   {p.Type.Description}    {p.Unit.Description}     {p.Price}     {p.ProductCategory.Count()} ");
            
            return str.ToString();
        }

        [HttpPost]
        [Route("api/AddProduct")]
        public string AddProduct(string code, string descripton, decimal price)
        {
            //TODO  create service to incapsulate this logic
            //TODO add existed
            var type = new DbAccess.Data.Type { Code = "S", Description = "small" };
            var unit = new Unit { Code = "ucc", Description = "USA" };
            var category = new Category { Code = "C06", Description = "Furniture" };
            var product = new Product
            {
                Code = code,
                Description = descripton,
                IsAvailable = true,
                DeliveryDate = DateTime.Now.Add(new TimeSpan(1, 1, 1)),
                Price = price,
                Type = type,
                Unit = unit
            };

            product.ProductCategory = new List<ProductCategory>
            {
                 new ProductCategory
                 {
                       Product = product,
                       Category = category
                 }
            };            

            _productRepository.Add(product);
            //TODO better solution is to implement Unit Of Work
            return _productRepository.Save();
            
        }
    }
}
