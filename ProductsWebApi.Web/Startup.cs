using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsWebApi.Data;
using ProductsWebApi.Web.Extensions;
using ProductsWebApi.Web.Middlewares;

namespace ProductsWebApi.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ProductsWebApiContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("ProductsConnection")));
            services.AddCustomizedAutoMapper();
            services.AddCustomizedServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseCustomizedExceptionHandling();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
