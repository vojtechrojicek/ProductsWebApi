using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProductsWebApi.Web.Facades.Products;
using ProductsWebApi.Web.Mappers;

namespace ProductsWebApi.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizedAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<ProductMappingProfile>();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static IServiceCollection AddCustomizedServices(this IServiceCollection services)
        {
            services.AddScoped<IProductFacade, ProductFacade>();

            return services;
        }
    }
}
