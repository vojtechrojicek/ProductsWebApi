﻿using AutoMapper;
using ProductsWebApi.Data;
using ProductsWebApi.Web.Contracts;
using ProductsWebApi.Web.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using ProductDb = ProductsWebApi.Data.Entities.Product;


namespace ProductsWebApi.Web.Facades.Products
{
    /// <summary>
    /// Facade for ProductsController/>.
    /// </summary>
    public class ProductFacade : IProductFacade
    {
        private readonly ProductsWebApiContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dbContext">Products dbContext</param>
        /// <param name="mapper">IMapper for mapping db entities to api dtos.</param>
        public ProductFacade(ProductsWebApiContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public Product Get(Guid id)
        {
            ProductDb product = GetSingle(id);
            return _mapper.Map<Product>(product);
        }

        /// <inheritdoc />
        public List<Product> GetAll()
        {
            var products = _dbContext.Products.ToList();
            return _mapper.Map<List<ProductDb>, List<Product>>(products);
        }

        /// <inheritdoc />
        public void Update(Guid id, ProductUpdate model)
        {
            ProductDb product = GetSingle(id);
            product.Description = model.Description;

            _dbContext.SaveChanges();
        }

        private ProductDb GetSingle(Guid id)
        {
            ProductDb product = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product is null)
            {
                throw new NotFoundException("Product has not been found.");
            }

            return product;
        }
    }
}
