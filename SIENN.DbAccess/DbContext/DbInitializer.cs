using SIENN.DbAccess.Repositories;
using System;

namespace SIENN.DbAccess.Data
{
    public class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var categories = new Category[]
             {
            
                new Category{Code="C01", Description="Home" },
                new Category{Code="C02", Description="Kitchen" },
                new Category{Code="C03", Description="Bathroom" },
                new Category{Code="C04", Description="Garden" },
                new Category{Code="C05", Description="Decoration" },
                new Category{Code="C06", Description="Furniture" }
             };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var types = new Type[] {
                new Type { Code="S", Description="small" },
                new Type { Code="L", Description="large" }
             };
            foreach (Type c in types)
            {
                context.Types.Add(c);
            }
            context.SaveChanges();

            var units = new Unit[] {
                new Unit { Code="ucc", Description="USA" },
                new Unit { Code="add", Description="Afrika" }
             };
            foreach (Unit c in units)
            {
                context.Units.Add(c);
            }
            context.SaveChanges();

            var products = new Product[]
            {
                new Product{Code="001",Description="Picture",   DeliveryDate=DateTime.Parse("2018-09-01"),IsAvailable=true,Price=12.0652M,Type=types[0], Unit=units[0]},
                new Product{Code="002",Description="Mixer",     DeliveryDate=DateTime.Parse("2003-09-01"),IsAvailable=true,Price=222.210456456M,Type=types[0], Unit=units[1]},
                new Product{Code="003",Description="chair",     DeliveryDate=DateTime.Parse("2002-09-01"),IsAvailable=true,Price=102.23454M,Type=types[0], Unit=units[0]},
                new Product{Code="004",Description="chair2",    DeliveryDate=DateTime.Parse("2002-09-01"),IsAvailable=true,Price=512.5442M,Type=types[1], Unit=units[0]},
                new Product{Code="005",Description="sofa",      DeliveryDate=DateTime.Parse("2018-02-21"),IsAvailable=false,Price=12.72M,Type=types[1], Unit=units[0]},
                new Product{Code="006",Description="Capucinator",DeliveryDate=DateTime.Parse("2013-09-01"),IsAvailable=true,Price=222.22M,Type=types[0], Unit=units[1]},
                new Product{Code="007",Description="Light",     DeliveryDate=DateTime.Parse("2012-09-01"),IsAvailable=true,Price=102.12M,Type=types[0], Unit=units[0]},
                new Product{Code="008",Description="Flower",    DeliveryDate=DateTime.Parse("2002-06-01"),IsAvailable=true,Price=52.24M,Type=types[1], Unit=units[0]},
            };
            foreach (Product s in products)
            {
                context.Products.Add(s);
            }
            context.SaveChanges();

            context.AddRange(
                   new ProductCategory { Product = products[0], Category = categories[0] },
                   new ProductCategory { Product = products[0], Category = categories[1] },
                   new ProductCategory { Product = products[0], Category = categories[2] },
                   new ProductCategory { Product = products[1], Category = categories[0] },
                   new ProductCategory { Product = products[1], Category = categories[1] },
                   new ProductCategory { Product = products[2], Category = categories[2] },
                   new ProductCategory { Product = products[3], Category = categories[3] },
                   new ProductCategory { Product = products[4], Category = categories[0] },
                   new ProductCategory { Product = products[5], Category = categories[5] },
                   new ProductCategory { Product = products[5], Category = categories[0] },
                   new ProductCategory { Product = products[5], Category = categories[1] },
                   new ProductCategory { Product = products[6], Category = categories[0] },
                   new ProductCategory { Product = products[6], Category = categories[1] },
                   new ProductCategory { Product = products[6], Category = categories[2] },
                   new ProductCategory { Product = products[6], Category = categories[3] },
                   new ProductCategory { Product = products[6], Category = categories[5] },
                   new ProductCategory { Product = products[7], Category = categories[0] },
                   new ProductCategory { Product = products[7], Category = categories[3] },
                   new ProductCategory { Product = products[7], Category = categories[4] }
                  );
            context.SaveChanges();
        }
    }
}
