using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NSubstitute;
using ProductsWebApi.Web.Exceptions;
using ProductsWebApi.Web.Middlewares;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProductsWebApi.Tests.Middlewares
{
    public class ErrorHandlingMiddlewareShould
    {
        [Theory]
        [InlineData(StatusCodes.Status200OK, StatusCodes.Status500InternalServerError)]
        [InlineData(StatusCodes.Status404NotFound, StatusCodes.Status404NotFound)]
        public void ChangeSuccessStatusCodeTo500AndRethrowException(int requestStatusCode, int responseStatusCode)
        {
            // Arrange
            var context = new DefaultHttpContext();
            var middleware = new ErrorHandlingMiddleware(innerHttpContext =>
            {
                innerHttpContext.Response.StatusCode = requestStatusCode;
                throw new Exception("Exception");
            }, Substitute.For<ILogger<ErrorHandlingMiddleware>>());

            // Act
            Func<Task> action = async () => await middleware.Invoke(context);

            // Assert
            action.Should().Throw<Exception>().WithMessage("Exception");
            context.Response.StatusCode.Should().Be(responseStatusCode);
        }

        [Fact]
        public async Task Return404StatusCodeForNotFoundException()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Response.StatusCode = StatusCodes.Status200OK;

            var middleware = new ErrorHandlingMiddleware(innerHttpContext =>
            {
                throw new NotFoundException();
            }, Substitute.For<ILogger<ErrorHandlingMiddleware>>());

            // Act
            await middleware.Invoke(context);

            // Assert
            context.Response.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}
