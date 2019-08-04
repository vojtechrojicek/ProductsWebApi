using FluentAssertions;
using ProductsWebApi.Data;
using System.Linq;
using Xunit;

namespace ProductsWebApi.Tests.DataInitializer
{
    public class ProductsWebApiInitializerShould
    {
        [Fact]
        public void SeedDbContext()
        {
            //Arrange
            ProductsWebApiContext dbContext = DbContextHelper.GetDbContext();

            //Act
            ProductsWebApiInitializer.Initialize(dbContext);

            // Assert
            dbContext.Products.Count().Should().BeGreaterThan(0);
        }
    }
}
