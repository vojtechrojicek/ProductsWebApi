using ProductsWebApi.Data.Entities;
using System;
using System.Linq;

namespace ProductsWebApi.Data
{
    public class ProductsWebApiInitializer
    {
        public static void Initialize(ProductsWebApiContext context)
        {
            var seeder = new ProductsWebApiInitializer();
            seeder.SeedProducts(context);
        }

        public void SeedProducts(ProductsWebApiContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            context.Products.AddRange(GetProducts());
            context.SaveChanges();
        }

        private Product[] GetProducts()
        {
            return new[]
            {
                new Product
                {
                    Id = new Guid("d739776c-532f-47b5-a218-ed3b8acad5de"),
                    Name = "Acer Aspire 5 Obsidian Black kovový",
                    ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f3&cd=NC028h0l6",
                    Price = 14990,
                    Description = "Notebook - Intel Core i5 8265U Whiskey Lake."
                },
                new Product
                {
                    Id = new Guid("462bc310-365e-4793-a9b6-ff0a5af85a48"),
                    Name = "HP Pavilion x360 15-dq0002nc Natural Silver Touch",
                    ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f3&cd=HPCN1011w5w9",
                    Price = 18490,
                    Description = "Tablet PC - Intel Core i3+ 8145U Whiskey Lake."
                },
                new Product
                {
                    Id = new Guid("9f5d9025-ed47-49ca-9fb2-3b71d897eb6a"),
                    Name = "Eternico Essential Wired Keyboard KD100CS",
                    ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f3&cd=AET0099b",
                    Price = 299,
                    Description = "Klávesnice kancelářská, drátová, chiclet klávesy."
                },
                new Product
                {
                    Id = new Guid("7b417428-cd89-4ff1-9248-6c2a89e1a3c6"),
                    Name = "PlayStation 4 Slim 500 GB",
                    ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f3&cd=MSX001sl",
                    Price = 7790,
                    Description = "Herní konzole - domácí, HDD 500 GB, Blu-ray, 1× herní ovladač, barva černá."
                },
                new Product
                {
                    Id = new Guid("8dbc0b73-69b9-480c-98f0-c09bd9db613a"),
                    Name = "24' Philips 243V7QJABF",
                    ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f3&cd=WC118b20c",
                    Price = 2390,
                    Description = "LCD monitor Full HD 1920×1080, IPS, LED."
                }
            };
        }
    }
}
