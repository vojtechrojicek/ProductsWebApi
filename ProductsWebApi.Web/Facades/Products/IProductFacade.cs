using ProductsWebApi.Web.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsWebApi.Web.Facades.Products
{
    public interface IProductFacade
    {
        Task<IList<Product>> GetAllAsync();
        Task<Product> GetAsync(Guid id);
        Task UpdateAsync(Guid id, ProductUpdate model);
    }
}
