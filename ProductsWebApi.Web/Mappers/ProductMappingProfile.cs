using AutoMapper;
using ProductDto = ProductsWebApi.Web.Contracts.Product;
using Product = ProductsWebApi.Data.Entities.Product;

namespace ProductsWebApi.Web.Mappers
{
    /// <summary>
    /// Automapper profile for maping database entity to Api Dto and back.
    /// </summary>
    public class ProductMappingProfile : Profile
    {
        /// <summary>
        /// Ctor. Configure profile.
        /// </summary>
        public ProductMappingProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
