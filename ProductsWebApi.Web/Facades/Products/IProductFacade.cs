using ProductsWebApi.Web.Contracts;
using System;
using System.Collections.Generic;

namespace ProductsWebApi.Web.Facades.Products
{
    public interface IProductFacade
    {
        List<Product> GetAll();
        Product Get(Guid id);
        void Update(Guid id, ProductUpdate model);
    }
}
