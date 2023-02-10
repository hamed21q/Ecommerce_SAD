using ES.Application.Contracts.Products.ProductCategory;
using ES.Application.Contracts.Products.ProductCategory.DTOs;
using ES.Application.Contracts.Products.ProductCategory.ViewModels;
using ES.Domain.DomainService;
using ES.Domain.Entities.Products.ProductCategory;
using System.Globalization;

namespace ES.Application.Products
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryService productCategoryService;
        private readonly IUnitOfWork unitOfWork;

        public ProductCategoryApplication(
            IProductCategoryService productCategoryService,
            IUnitOfWork unitOfWork
        )
        {
            this.productCategoryService = productCategoryService;
            this.unitOfWork = unitOfWork;
        }

        public async Task Add(CreateProductCategoryCommand command)
        {
            var parent = await productCategoryService.GetBy(command.Parent);
            var grade = parent.Grade + 1;
            var productCategory = new ProductCategory(command.Title, command.Parent, grade);
            await productCategoryService.Add(productCategory);
            await unitOfWork.Save();
        }

        public async Task Remove(long id)
        {
            var productCategory = await productCategoryService.GetBy(id);
            productCategory.Remove();
            await unitOfWork.Save();
        }
        public async Task Activate(long id)
        {
            var productCategory = await productCategoryService.GetBy(id);
            productCategory.Activate();
            await unitOfWork.Save();
        }
        public async Task<List<ProductCategoryViewModel>> GetAll()
        {
            var list = await productCategoryService.GetAll();
            var viewModel = new List<ProductCategoryViewModel>();
            foreach (var item in list)
            {
                viewModel.Add(new ProductCategoryViewModel
                {
                    Id = item.Id,
                    CreationDate = item.CreationDate.ToString(CultureInfo.InvariantCulture),
                    IsDeleted = item.IsDeleted,
                    Title = item.Title,
                    Parent = item.Parent?.Id,
                    Grade = item.Grade
                });
            }
            return viewModel;
        }

        public async Task<DetailedProductCategoryViewModel> GetBy(long id)
        {
            var productCategory = await productCategoryService.GetBy(id);
            var childView = new List<ProductCategoryViewModel>();
            var subCategories = await productCategoryService.GetSubCategories(id);
            subCategories.ForEach(c => childView.Add(convert(c)));
            return new DetailedProductCategoryViewModel
            {
                Id = productCategory.Id,
                CreationDate = productCategory.CreationDate.ToString(CultureInfo.InvariantCulture),
                Title = productCategory.Title,
                IsDeleted = productCategory.IsDeleted,
                Parent = productCategory.Parent?.Id,
                Grade = productCategory.Grade,
                childCategories = childView
            };
        }
        private ProductCategoryViewModel convert(ProductCategory p)
        {
            return new ProductCategoryViewModel
            {
                Id = p.Id,
                CreationDate = p.CreationDate.ToString(CultureInfo.InvariantCulture),
                Grade = p.Parent.Grade + 1,
                IsDeleted = p.IsDeleted,
                Parent = p.ParentId,
                Title = p.Title
            };
        }
        public async Task<bool> IsValid(long id)
        {
            return await productCategoryService.Exist(x => x.Id == id);
        }

        public async Task Edit(EditProductCategoryCommand command)
        {
            var productCategory = await productCategoryService.GetBy(command.Id);
            var parent = await productCategoryService.GetBy(command.Parent);
            var grade = parent.Grade + 1;
            productCategory.Edit(command.Parent, command.Title, grade);
            await unitOfWork.Save();
        }
    }
}