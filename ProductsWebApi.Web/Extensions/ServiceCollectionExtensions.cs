using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProductsWebApi.Web.Facades.Products;
using ProductsWebApi.Web.Mappers;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace ProductsWebApi.Web.Extensions
{
    /// <summary>
    /// Extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add AutoMapper profile to IoC.
        /// </summary>
        /// <param name="services">Service collection where AutoMaper is registered.</param>
        /// <returns>Returns input <paramref name="services"/>.</returns>
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

        /// <summary>
        /// Add web api services to IoC.
        /// </summary>
        /// <param name="services">Service collection where services are registered.</param>
        /// <returns>Returns input <paramref name="services"/>.</returns>
        public static IServiceCollection AddCustomizedServices(this IServiceCollection services)
        {
            services.AddScoped<IProductFacade, ProductFacade>();

            return services;
        }

        /// <summary>
        /// Add Swagger to IoC.
        /// </summary>
        /// <param name="services">Service collection where Swagger is registered.</param>
        /// <returns>Returns input <paramref name="services"/>.</returns>
        public static IServiceCollection AddCustomizedSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Products API Documentation", Version = "v1" });

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
