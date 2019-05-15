using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using TechEd.Api.Contracts;

namespace TechEd.Api.Services
{
    public class ProductService
    {
        private readonly IActionResultExecutor<ObjectResult> executor;

        public ProductService(IActionResultExecutor<ObjectResult> executor)
        {
            this.executor = executor;
        }

        public async Task CreateProduct(HttpContext context)
        {
        }

        public async Task GetProducts(HttpContext context)
        {
            int id = int.Parse(context.Request.RouteValues["id"].ToString());

            Product product = new Product() {Title = "iPhone", Description = "Telefon s ID " + id};
            ActionContext actionContext = new ActionContext(context, context.GetRouteData(), new ActionDescriptor() );
            
            OkObjectResult result = new OkObjectResult(product);

            await executor.ExecuteAsync(actionContext, result);
            
            // context.Response.Headers["Content-Type"] = "application/json";
            // await context.Response.WriteAsync(JsonConvert.SerializeObject(product));
        }
    }
}