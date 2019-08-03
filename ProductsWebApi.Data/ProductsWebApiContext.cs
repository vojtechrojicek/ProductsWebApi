using Microsoft.EntityFrameworkCore;
using ProductsWebApi.Data.Configurations;
using ProductsWebApi.Data.Entities;

namespace ProductsWebApi.Data
{
    public class ProductsWebApiContext : DbContext
    {
        public ProductsWebApiContext(DbContextOptions<ProductsWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
