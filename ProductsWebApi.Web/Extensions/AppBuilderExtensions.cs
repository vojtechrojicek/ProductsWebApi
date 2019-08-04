using Microsoft.AspNetCore.Builder;

namespace ProductsWebApi.Web.Extensions
{
    /// <summary>
    /// IApplicationBuilder extensions.
    /// </summary>
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Add customized swagger to pipeline.
        /// </summary>
        /// <param name="app">Application builder.</param>
        /// <returns>Application builder with swagger.</returns>
        public static IApplicationBuilder UseCustomizedSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products Web API V1");
            });

            return app;
        }
    }
}
