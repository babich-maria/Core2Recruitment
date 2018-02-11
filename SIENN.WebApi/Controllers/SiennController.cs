using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Data;
using SIENN.DbAccess.Repositories;
using System;
using System.Collections.Generic;
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
        [Route("api/GetAvailable")]
        public string GetAvailable(int skip, int take)
        {
            var available = _productRepository.GetAvailableProducts(skip, take);

            StringBuilder MyStringBuilder = new StringBuilder(string.Empty);
            foreach (var item in available)
            {
                MyStringBuilder.AppendLine($"{item.Code}   {item.Description}");
            }

            return MyStringBuilder.ToString();
        }

        [HttpGet]
        [Route("api/GetFiltered")]
        public string GetFiltered(FieldType fieldType, string value)
        {
            System.Func<Product, bool> predicate;
            //switch (fieldType) {
            //    case Category:
            //        predicate = new System.Func<Product, bool>(Type.Description == "small");
            //    }



            var available = _productRepository.GetFilteredProducts(fieldType, value);

            StringBuilder MyStringBuilder = new StringBuilder();
            MyStringBuilder.AppendLine($"Description  Type");
            MyStringBuilder.AppendLine($"-----------------");
            foreach (var item in available)
            {
                MyStringBuilder.AppendLine($"{item.Description}   {item.Type.Description}"/*, item.ProductCategory.*/);
            }

            return MyStringBuilder.ToString();
        }


        [HttpGet]
        [Route("api/GetProductInfo")]
        public string GetProductInfo(string code)
        {
            var available = _productRepository.GetProductInfo(code);

            StringBuilder MyStringBuilder = new StringBuilder(string.Empty);
            foreach (var item in available)
            {
                MyStringBuilder.AppendLine(item.Description);
            }

            return MyStringBuilder.ToString();
        }

        [HttpPost]
        [Route("api/AddProduct")]
        public void AddProduct(string code, string descripton, decimal price)
        {

            var type = new SIENN.DbAccess.Data.Type { Code = "S", Description = "small" };
            var unit = new Unit { Code = "ucc", Description = "USA" };
            var category = new Category { Code = "C06", Description = "Furniture" };
            var product = new Product
            {
                Code = code,
                Description = descripton,
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
            //TODO better to implement Unit Of Work
            _productRepository.Save();
            
        }


    }

}
