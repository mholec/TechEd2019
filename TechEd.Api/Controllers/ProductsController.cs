using Microsoft.AspNetCore.Mvc;
using TechEd.Api.Contracts;

namespace TechEd.Api.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [Route("products/{id:int}")]
        [HttpGet, HttpHead]
        public IActionResult GetProducts(int id)
        {
            return Ok(new Product()
            {
                Title = "TechEd", Description = "Popisek " + id
            });
        }
    }
}