using ES.Application.Contracts.Product;
using ES.Domain.Entities.Product;

namespace ES.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductService productService;

        public ProductApplication(IProductService productService)
        {
            this.productService = productService;
        }
    }
}