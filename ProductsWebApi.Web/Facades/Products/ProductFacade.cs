using ProductsWebApi.Web.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsWebApi.Web.Facades.Products
{
    public class ProductFacade : IProductFacade
    {
        public Task<Product> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, ProductUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
