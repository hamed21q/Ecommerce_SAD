using ES.Application.Contracts.ProductCategory;
using ES.Application.Contracts.ProductCategory.DTOs;
using ES.Application.Contracts.ProductCategory.ViewModels;
using ES.Domain;
using ES.Domain.Entities.ProductCategory;
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
            var parentGrade = productCategoryService.GetBy(command.Parent).Grade;
            var productCategory = new ProductCategory(command.Title, command.Parent, ++parentGrade);
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
                    Parent = item.Parent?.Id,
                    Grade = item.Grade
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
                Parent = productCategory.Parent?.Id,
                Grade = productCategory.Grade
            };
        }

        public bool IsValid(long id)
        {
            return productCategoryService.Exist(x => x.Id == id);
        }

        public void Edit(EditProductCategoryCommand command)
        {
            var productCategory = productCategoryService.GetBy(command.Id);
            var parentGrade = productCategoryService.GetBy(command.Parent).Grade;
            productCategory.Edit(command.Parent, command.Title, parentGrade++);
            unitOfWork.Save();
        }
    }
}