using ES.Application.Contracts.ProductCategory;
using ES.Domain;
using ES.Domain.ProductCategory;

namespace ES.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryService productCategoryService;
        private readonly IUnitOfWork unitOfWork;

        public ProductCategoryApplication(IProductCategoryService productCategoryService, IUnitOfWork unitOfWork)
        {
            this.productCategoryService = productCategoryService;
            this.unitOfWork = unitOfWork;
        }

        public void Add(CreateProductCategoryCommand command)
        {
            unitOfWork.BeginTran();
            var productCategory = new ProductCategory(command.Title, command.Parent);
            productCategoryService.Add(productCategory);
            unitOfWork.CommitTran();
        }
    }
}