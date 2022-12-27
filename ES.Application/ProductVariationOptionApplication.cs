using ES.Application.Contracts.ProductVariationOption;
using ES.Application.Contracts.ProductVariationOption.DTOs;
using ES.Application.Contracts.ProductVariationOption.ViewModels;
using ES.Domain.DomainService;
using ES.Domain.Entities.Products.ProductVariationOption;
using ES.Domain.Entities.ProductVariationOption;

namespace ES.Application
{
    public class ProductVariationOptionApplication : IProductVariationOptionApplication
    {
        private readonly IProductVariationOptionService productVariationOptionService;
        private readonly IUnitOfWork unitOfWork;

        public ProductVariationOptionApplication(IProductVariationOptionService productVariationOptionService, IUnitOfWork unitOfWork)
        {
            this.productVariationOptionService = productVariationOptionService;
            this.unitOfWork = unitOfWork;
        }

        public void Add(CreateProductVariationOptionCommand command)
        {
            var option = new ProductVariationOption(command.VariationId, command.Value);
            productVariationOptionService.Add(option);
            unitOfWork.Save();
        }

        public void Delete(long id)
        {
            var option = productVariationOptionService.GetBy(id);
            productVariationOptionService.Delete(option);
            unitOfWork.Save();
        }

        public void Edit(EditProductVariationOptionCommand command)
        {
            var option = productVariationOptionService.GetBy(command.Id);
            option.Edit(command.VariationId, command.Value);
            unitOfWork.Save();
        }

        public ProductVariationOptionViewModel GetBy(long id)
        {
            var option = productVariationOptionService.GetBy(id);
            return new ProductVariationOptionViewModel
            {
                VariationId = option.VariationId,
                Value = option.Value
            };
        }

        public List<ProductVariationOptionViewModel> GetByVariation(long variationId)
        {
            var list = productVariationOptionService.GetbyVariation(variationId);
            var view = new List<ProductVariationOptionViewModel>();
            foreach (var item in list)
            {
                view.Add(new ProductVariationOptionViewModel
                {
                    VariationId = item.VariationId,
                    Value = item.Value
                });
            }
            return view;
        }

        public bool IsValid(long id)
        {
            return productVariationOptionService.Exist(pvo => pvo.Id == id);
        }
    }
}
