using AutoMapper;
using ProductDto = ProductsWebApi.Web.Contracts.Product;
using Product = ProductsWebApi.Data.Entities.Product;

namespace ProductsWebApi.Web.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
