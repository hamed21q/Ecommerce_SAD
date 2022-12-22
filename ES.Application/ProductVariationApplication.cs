using ES.Application.Contracts.ProductVariation.DTOs;
using ES.Application.Contracts.ProductVariation.ViewModels;
using ES.Domain.DomainService;
using ES.Domain.Entities.ProductVariation;

namespace ES.Application
{
    public class ProductVariationApplication : Contracts.ProductVariation.IProductVariationApplication
    {
        private readonly IProductVariationService productVariationService;
        private readonly IUnitOfWork unitOfWork;


        public ProductVariationApplication(IProductVariationService productVariationService, IUnitOfWork unitOfWork)
        {
            this.unitOfWork= unitOfWork;
            this.productVariationService = productVariationService;
        }

        public void Add(CreateProductVariationCommand command)
        {
            var variation = new ProductVariation(command.CategoryId, command.Name);
            productVariationService.Add(variation);
            unitOfWork.Save();
        }

        public void Edit(EditProductVariationCommand command)
        {
            var variation = productVariationService.GetBy(command.Id);
            variation.Edit(command.CategoryId, command.Name);
            unitOfWork.Save();
        }

        public List<ProductVariationViewModel> GetAll()
        {
            var list = productVariationService.GetAll();
            var view = new List<ProductVariationViewModel>();
            foreach (var item in list)
            {
                view.Add(new ProductVariationViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    CategoryId = item.CategoryId
                });
            }
            return view;
        }

        public ProductVariationViewModel GetBy(long id)
        {
            var variation = productVariationService.GetBy(id);
            return new ProductVariationViewModel
            {
                Id = id,
                Name = variation.Name,
                CategoryId = variation.CategoryId
            };
        }

        public bool IsValid(long id)
        {
            return productVariationService.Exist(x => x.Id == id);
        }

        public void Remove(long id)
        {
            var variation = productVariationService.GetBy(id);
            productVariationService.Delete(variation);
            unitOfWork.Save();
        }
    }
}
