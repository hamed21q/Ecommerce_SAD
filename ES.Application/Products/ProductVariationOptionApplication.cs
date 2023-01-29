using ES.Application.Contracts.Products.ProductVariationOption;
using ES.Application.Contracts.Products.ProductVariationOption.DTOs;
using ES.Application.Contracts.Products.ProductVariationOption.ViewModels;
using ES.Domain.DomainService;
using ES.Domain.Entities.Products.ProductVariationOption;

namespace ES.Application.Products
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

        public async Task Add(CreateProductVariationOptionCommand command)
        {
            var option = new ProductVariationOption(command.VariationId, command.Value);
            await productVariationOptionService.Add(option);
            await unitOfWork.Save();
        }

        public async Task Delete(long id)
        {
            var option = await productVariationOptionService.GetBy(id);
            productVariationOptionService.Delete(option);
            await unitOfWork.Save();
        }

        public async Task Edit(EditProductVariationOptionCommand command)
        {
            var option = await productVariationOptionService.GetBy(command.Id);
            option.Edit(command.VariationId, command.Value);
            await unitOfWork.Save();
        }

        public async Task<ProductVariationOptionViewModel> GetBy(long id)
        {
            var option = await productVariationOptionService.GetBy(id);
            return new ProductVariationOptionViewModel
            {
                VariationId = option.VariationId,
                Value = option.Value
            };
        }

        public async Task<List<ProductVariationOptionViewModel>> GetByVariation(long variationId)
        {
            var list = await productVariationOptionService.GetbyVariation(variationId);
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

        public async Task<bool> IsValid(long id)
        {
            return await productVariationOptionService.Exist(pvo => pvo.Id == id);
        }
    }
}
