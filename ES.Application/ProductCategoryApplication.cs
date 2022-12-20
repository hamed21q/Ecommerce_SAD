using ES.Application.Contracts.ProductCategory;
using ES.Application.Contracts.ProductCategory.DTOs;
using ES.Application.Contracts.ProductCategory.ViewModels;
using ES.Domain;
using ES.Domain.ProductCategory;
using System.Globalization;

namespace ES.Application
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

        public void Add(CreateProductCategoryCommand command)
        {
            var productCategory = new ProductCategory(command.Title, command.Parent);
            productCategoryService.Add(productCategory);
            unitOfWork.Save();
        }

        public void Remove(long id)
        {
            var productCategory = productCategoryService.GetBy(id);
            productCategory.Remove();
            unitOfWork.Save();
        }
        public void Activate(long id)
        {
            var productCategory = productCategoryService.GetBy(id);
            productCategory.Activate();
            unitOfWork.Save();
        }
        public List<ProductCategoryViewModel> GetAll()
        {
            var list = productCategoryService.GetAll();
            var viewModel = new List<ProductCategoryViewModel>();
            foreach (var item in list)
            {
                viewModel.Add(new ProductCategoryViewModel {
                    Id = item.Id,
                    CreationDate = item.CreationDate.ToString(CultureInfo.InvariantCulture),
                    IsDeleted = item.IsDeleted,
                    Title = item.Title,
                    Parent = item.Parent?.Title
                });
            }
            return viewModel;
        }

        public ProductCategoryViewModel GetBy(long id)
        {
            var productCategory = productCategoryService.GetBy(id);
            return new ProductCategoryViewModel
            {
                Id = productCategory.Id,
                CreationDate = productCategory.CreationDate.ToString(CultureInfo.InvariantCulture),
                Title = productCategory.Title,
                IsDeleted = productCategory.IsDeleted,
                Parent = productCategory.Parent?.Title
            };
        }

        public bool IsValid(long id)
        {
            return productCategoryService.Exist(x => x.Id == id);
        }

        public void Rename(RenameProductCategoryCommand command)
        {
            var productCategory = productCategoryService.GetBy(command.Id);
            productCategory.Rename(command.Parent, command.Title);
            unitOfWork.Save();
        }
    }
}