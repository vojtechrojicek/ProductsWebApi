using Microsoft.EntityFrameworkCore;
using ProductsWebApi.Data;
using System;

namespace ProductsWebApi.Tests
{
    public static class DbContextHelper
    {
        public static ProductsWebApiContext GetDbContext()
        {
            var builder = new DbContextOptionsBuilder<ProductsWebApiContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            var dbContext = new ProductsWebApiContext(builder.Options);

            return dbContext;
        }
    }
}
