using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsWebApi.Web.Contracts;
using ProductsWebApi.Web.Facades.Products;
using System;
using System.Collections.Generic;

namespace ProductsWebApi.Web.Controllers
{
    /// <summary>
    /// Products controller.
    /// </summary>
    /// <response code="200">Ok.</response>
    /// <response code="400">Incorrect request. Check response message for more details.</response>
    /// <response code="500">Unexpected error occurred.</response>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ProductsController : ControllerBase
    {
        private readonly IProductFacade _productFacade;
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="customerFacade">Facade providing operations on products.</param>
        public ProductsController(IProductFacade customerFacade)
        {
            _productFacade = customerFacade;
        }

        /// <summary>
        /// Returns all product.
        /// </summary>
        /// <returns>List of all products.</returns>
        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            return Ok(_productFacade.GetAll());
        }

        /// <summary>
        /// Returns product by id.
        /// </summary>
        /// <param name="id">Id of the product.</param>        
        /// <returns>Requested product.</returns>
        /// <response code="404">If product with <paramref name="id"/> doesn't exist.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> GetProduct(Guid id)
        {
            return Ok(_productFacade.Get(id));
        }

        /// <summary>
        /// Updates product data specified by id.
        /// </summary>
        /// <param name="id">Id of the product.</param>
        /// <param name="product">Data for updating product.</param>
        /// <response code="200">Updated.</response>
        /// <response code="404">If product with <paramref name="id"/> doesn't exist.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdateDescription(Guid id, ProductUpdate product)
        {
            _productFacade.Update(id, product);
            return Ok();
        }
    }
}
