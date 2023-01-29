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

        public async Task Add(CreateProductCommand command)
        {
            var product = new Product(
                command.Name,
                command.Description, 
                command.CategoryId, 
                command.Image
            );
            await productService.Add(product);
            await unitOfWork.Save();

        }
        public async Task Edit(EditProductCommand command)
        {
            var product = await productService.GetBy(command.Id);
            product.Edit(
                command.Name,
                command.Description,
                command.CategoryId,
                command.Image
            );
            await unitOfWork.Save();
        }

        public async Task Delete(long id)
        {
            var product = await productService.GetBy(id);
            productService.Delete(product);
            await unitOfWork.Save(); 
        }

        public async Task<DetailedProductViewModel> GetBy(long id)
        {
            var product = await productService.GetBy(id);
            return new DetailedProductViewModel
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Image = product.Image,
                Name = product.Name,
                MinimumPrice = await productService.GetMinimumPrice(product.Id),
                TotalQuantity = await productService.GetTotalQuantity(product.Id),
                items = await itemApplication.GetAllSibllings(product.Id)
            };
        }

        public async Task<List<ProductViewModel>> GetByCategory(long categoryId)
        {
            var products = await productService.GetByCategory(categoryId);
            var view = new List<ProductViewModel>();
            foreach (var item in products)
            {
                view.Add(await Convert(item));
            }
            return view;
        }

        public async Task<bool> IsValid(long id)
        {
            return await productService.Exist(p => p.Id == id);
        }

        private async Task<ProductViewModel> Convert(Product p)
        {
            return new ProductViewModel
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Description = p.Description,
                Image = p.Image,
                Name = p.Name,
                MinimumPrice = await productService.GetMinimumPrice(p.Id),
                TotalQuantity = await productService.GetTotalQuantity(p.Id),
            };
        }

        public async Task<List<ProductItemViewModel>> GetProductItems(long id)
        {
            return await itemApplication.GetAllSibllings(id);
        }

       
    }
}