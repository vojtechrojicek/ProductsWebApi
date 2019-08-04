using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using ProductsWebApi.Data;
using ProductsWebApi.Web.Contracts;
using ProductsWebApi.Web.Controllers;
using ProductsWebApi.Web.Exceptions;
using ProductsWebApi.Web.Facades.Products;
using ProductsWebApi.Web.Mappers;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProductsWebApi.Tests.Controllers
{
    public class ProductsControllerShould
    {
        [Fact]
        public void ReturnsAllInitializedProducts()
        {
            //Arrange
            var productsController = new ProductsController(GetProductsFacade());

            //Act
            ActionResult<List<Product>> productsResult = productsController.GetProducts();

            //Assert
            productsResult.Result.Should().BeAssignableTo(typeof(OkObjectResult));
            (productsResult.Result as OkObjectResult).StatusCode.Should().Be(200);

            var products = (productsResult.Result as OkObjectResult).Value as List<Product>;
            products.Count.Should().Be(5);
        }

        [Fact]
        public void ReturnsConcreteProductByGivenId()
        {
            //Arrange
            var productsController = new ProductsController(GetProductsFacade());
            var guid = new Guid("7b417428-cd89-4ff1-9248-6c2a89e1a3c6");

            //Act
            ActionResult<Product> productsResult = productsController.GetProduct(guid);

            //Assert
            productsResult.Result.Should().BeAssignableTo(typeof(OkObjectResult));
            (productsResult.Result as OkObjectResult).StatusCode.Should().Be(200);

            var product = (productsResult.Result as OkObjectResult).Value as Product;
            product.Id.Should().Be(guid);
            product.Name.Should().Be("PlayStation 4 Slim 500 GB");
            product.ImgUri.Should().Be("https://cdn.alza.cz/ImgW.ashx?fd=f3&cd=MSX001sl");
            product.Price.Should().Be(7790);
            product.Description.Should().Contain("Herní konzole");
        }

        [Fact]
        public void ReturnsNotFoundExceptionWhenGettingNotExistingId()
        {
            //Arrange
            var productsController = new ProductsController(GetProductsFacade());
            var guid = new Guid("8b417428-cd89-4ff1-9248-6c2a89e1a3c6");

            //Act
            Func<ActionResult<Product>> action = () => productsController.GetProduct(guid);

            //Assert
            action.Should().Throw<NotFoundException>().WithMessage("Product has not been found.");
        }

        [Fact]
        public void UpdateProductDescription()
        {
            //Arrange
            var productsController = new ProductsController(GetProductsFacade());
            var guid = new Guid("7b417428-cd89-4ff1-9248-6c2a89e1a3c6");
            var productUpdate = new ProductUpdate() { Description = "New desc." };

            //Act
            ActionResult<Product> productsResult = productsController.UpdateDescription(guid, productUpdate);

            //Assert
            productsResult.Result.Should().BeAssignableTo(typeof(OkResult));
            (productsResult.Result as OkResult).StatusCode.Should().Be(200);

            var getResult = (productsController.GetProduct(guid).Result as OkObjectResult);
            var product = getResult.Value as Product;
            product.Description.Should().Be(productUpdate.Description);
        }

        [Fact]
        public void ReturnsNotFoundExceptionWhenupdatingNotExistingId()
        {
            //Arrange
            var productsController = new ProductsController(GetProductsFacade());
            var guid = new Guid("8b417428-cd89-4ff1-9248-6c2a89e1a3c6");
            var productUpdate = new ProductUpdate() { Description = "New desc." };

            //Act
            Func<ActionResult<Product>> action = () => productsController.UpdateDescription(guid, productUpdate);

            //Assert
            action.Should().Throw<NotFoundException>().WithMessage("Product has not been found.");
        }

        private static IProductFacade GetProductsFacade()
        {
            ProductsWebApiContext dbContext = DbContextHelper.GetDbContext();
            ProductsWebApiInitializer.Initialize(dbContext);

            var mappingConfig = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<ProductMappingProfile>();
            });

            return new ProductFacade(dbContext, mappingConfig.CreateMapper());
        }
    }
}
