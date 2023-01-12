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
        private readonly IProductItemApplication itemApplication;
        private readonly IUnitOfWork unitOfWork;
        public ProductApplication(
            IProductService productService,
            IUnitOfWork unitOfWork,
            IProductItemApplication itemApplication
            )
        {
            this.unitOfWork = unitOfWork;
            this.productService = productService;
            this.itemApplication = itemApplication;
        }

        public void Add(CreateProductCommand command)
        {
            var product = new Product(
                command.Name,
                command.Description, 
                command.CategoryId, 
                command.Image
            );
            productService.Add(product);
            unitOfWork.Save();

        }
        public void Edit(EditProductCommand command)
        {
            var product = productService.GetBy(command.Id);
            product.Edit(
                command.Name,
                command.Description,
                command.CategoryId,
                command.Image
            );
            unitOfWork.Save();
        }

        public void Delete(long id)
        {
            var product = productService.GetBy(id);
            productService.Delete(product);
            unitOfWork.Save(); 
        }

        public DetailedProductViewModel GetBy(long id)
        {
            var product = productService.GetBy(id);
            return new DetailedProductViewModel
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Image = product.Image,
                Name = product.Name,
                MinimumPrice = productService.GetMinimumPrice(product.Id),
                TotalQuantity = productService.GetTotalQuantity(product.Id),
                items = itemApplication.GetAllSibllings(product.Id)
            };
        }

        public List<ProductViewModel> GetByCategory(long categoryId)
        {
            var products = productService.GetByCategory(categoryId);
            var view = new List<ProductViewModel>();
            foreach (var item in products)
            {
                view.Add(Convert(item));
            }
            return view;
        }

        public bool IsValid(long id)
        {
            return productService.Exist(p => p.Id == id);
        }

        private ProductViewModel Convert(Product p)
        {
            return new ProductViewModel
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Description = p.Description,
                Image = p.Image,
                Name = p.Name,
                MinimumPrice = productService.GetMinimumPrice(p.Id),
                TotalQuantity = productService.GetTotalQuantity(p.Id),
            };
        }

        public List<ProductItemViewModel> GetProductItems(long id)
        {
            return itemApplication.GetAllSibllings(id);
        }
    }
}