using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TechEd.Api.Services;

namespace TechEd.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ProductService>();
            services.AddScoped<ApiMapper>();

            var mvc = services.AddMvcCore();
            mvc.AddXmlSerializerFormatters();
            mvc.SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //mvc.ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });

            /*var mvcBuilder = services.AddControllers(options =>
            {
            });

            mvcBuilder.AddXmlSerializerFormatters();*/
        }

        public void Configure(IApplicationBuilder app, ApiMapper mapper)
        {
            app.UseRouting();

            app.UseEndpoints(builder =>
            {
                builder.MapGet("/products/{id:int}", mapper.Products.GetProducts);
                builder.MapPost("/products", mapper.Products.CreateProduct);
            });
        }
    }
}