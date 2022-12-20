using ES.Application.Contracts.Product;
using ES.Application.Contracts.Product.DTOs;
using ES.Domain;
using ES.Domain.Entities.Product;

namespace ES.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductService productService;
        private readonly IUnitOfWork unitOfWork;

        public ProductApplication(IProductService productService, IUnitOfWork unitOfWork)
        {
            this.unitOfWork= unitOfWork;
            this.productService = productService;
        }

        public void Add(CreateProductCommand command)
        {
            var product = new Product(command.Name, command.Description, command.CategoryId, command.Image);
            productService.Add(product);
            unitOfWork.Save();
        }
        public bool IsValid(long id)
        {
            return productService.Exist(id => id.Equals(id));
        }
    }
}