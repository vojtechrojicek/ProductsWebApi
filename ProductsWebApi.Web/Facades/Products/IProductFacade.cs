using ProductsWebApi.Web.Contracts;
using System;
using System.Collections.Generic;

namespace ProductsWebApi.Web.Facades.Products
{
    /// <summary>
    /// Interface which describe facade used in ProductsController/>.
    /// </summary>
    public interface IProductFacade
    {
        /// <summary>
        /// Returns all product.
        /// </summary>
        /// <returns>List of all products.</returns>
        List<Product> GetAll();

        /// <summary>
        /// Returns product by id.
        /// Throws NotFoundException when product not found.
        /// </summary>
        /// <param name="id">Id of the product.</param>
        /// <returns>Requested product.</returns>
        Product Get(Guid id);

        /// <summary>
        /// Updates product data specified by id.
        /// Throws NotFoundException when product not found.
        /// </summary>
        /// <param name="id">Id of the product.</param>
        /// <param name="model">Data for updating product.</param>
        void Update(Guid id, ProductUpdate model);
    }
}
