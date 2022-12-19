using ES.Application.Contracts.ProductCategory;
using ES.Domain;
using ES.Domain.ProductCategory;

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

        public List<ProductCategoryViewModel> GetAll()
        {
            var list = productCategoryService.GetAll();
            var viewModel = new List<ProductCategoryViewModel>();
            foreach (var item in list)
            {
                viewModel.Add(new ProductCategoryViewModel { 
                    Title = item.Title, Parent = item.Parent.Title
                });
            }
            return viewModel;
        }

        public bool IsValid(long id)
        {
            return productCategoryService.Exist(x => x.Id == id);
        }
    }
}