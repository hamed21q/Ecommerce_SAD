using ES.Application.Contracts.Product;
using ES.Application.Contracts.Product.DTOs;
using ES.Application.Contracts.Product.ViewModels;
using ES.Domain.DomainService;
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
            return productService.Exist(x => x.Id == id);
        }
        public void Edit(EditProductCommand command)
        {
            var product = productService.GetBy(command.Id);
            product.Edit(command.Name, command.Description, command.CategoryId, command.Image);
            unitOfWork.Save();
        }
        public ProductViewModel GetBy(long id)
        {
            var product = productService.GetBy(id);
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Image = product.Image
            };
        }
        public List<ProductViewModel> GetByCategory(long categoryId)
        {
            var products = productService.GetProductsBy(categoryId);
            var viewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                viewModels.Add(new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    CategoryId = product.CategoryId,
                    Image = product.Image
                });
            }
            return viewModels;
        }
        public void Delete(long id)
        {
            var product = productService.GetBy(id);
            productService.Delete(product);
            unitOfWork.Save();
        }
    }
}