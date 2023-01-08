using ES.Application.Contracts.Products.Product;
using ES.Application.Contracts.Products.Product.DTOs;
using ES.Application.Contracts.Products.Product.ViewModels;
using ES.Application.Contracts.Products.ProductItem;
using ES.Application.Contracts.Products.ProductItem.ViewModels;
using ES.Domain.DomainService;
using ES.Domain.Entities.Products.Product;

namespace ES.Application.Products
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductService productService;
        private readonly IUnitOfWork unitOfWork;

        private readonly IProductItemApplication itemApplication;

        public ProductApplication(IProductService productService, IUnitOfWork unitOfWork, IProductItemApplication itemApplication)
        {
            this.unitOfWork = unitOfWork;
            this.productService = productService;
            this.itemApplication = itemApplication;
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
            var totalQuantity = 0;
            product.ProductItems.ForEach(i => totalQuantity += i.Quantity);
            var minPrice = product.ProductItems.MinBy(p => p.Price).Price;
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Image = product.Image,
                MinimumPrice = minPrice,
                TotalQuantity = totalQuantity
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

        public ProductViewModel Convert(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Image = product.Image
            };
        }

        public List<ProductViewModel> GetAll()
        {
            var list = productService.GetAll();
            var viewModels = new List<ProductViewModel>();
            foreach (var product in list)
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

        public List<ProductItemViewModel> GetAllVariant(long id)
        {
            var product = productService.GetBy(id);
            List<ProductItemViewModel> list = new List<ProductItemViewModel>();
            product.ProductItems.ForEach(item => list.Add(itemApplication.Convert(item)));
            return list;
        }
    }
}