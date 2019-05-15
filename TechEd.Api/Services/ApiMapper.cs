namespace TechEd.Api.Services
{
    public class ApiMapper
    {
        private readonly ProductService productService;

        public ApiMapper(ProductService productService)
        {
            this.productService = productService;
        }

        public ProductService Products => productService;
    }
}