using ES.Application.Contracts.Products.ProductConfiguration;
using ES.Application.Contracts.Products.ProductConfiguration.DTOs;
using ES.Application.Contracts.Products.ProductConfiguration.ViewModel;
using ES.Application.Contracts.Products.ProductVariation;
using ES.Domain.DomainService;
using ES.Domain.Entities.Products.ProductConfiguration;

namespace ES.Application.Products
{
    public class ProductConfigurationApplication : IProductConfigurationApplication
    {
        private readonly IProductConfigurationService productConfigurationService;
        private readonly IProductVariationApplication productVariationApplication;
        private readonly IUnitOfWork unitOfWork;

        public ProductConfigurationApplication(
            IProductConfigurationService productConfigurationService,
            IUnitOfWork unitOfWork,
            IProductVariationApplication productVariationApplication
        )
        {
            this.productVariationApplication = productVariationApplication;
            this.productConfigurationService = productConfigurationService;
            this.unitOfWork = unitOfWork;
        }

        public async Task Add(List<CreateProductConfigurationCommand> variations)
        {
            foreach (var item in variations)
            {
                await productConfigurationService.Add(new ProductConfiguration(item.ProductItemId, item.VariationOptionId));
            }
            await unitOfWork.Save();
        }

        public async Task Edit(long id, long productItemId, long variationOptionId)
        {
            var conf = await productConfigurationService.GetBy(id);
            conf.Edit(productItemId, variationOptionId);
            await unitOfWork.Save();
        }

        public async Task<ProductConfigurationViewModel> GetBy(long id)
        {
            var option = await productConfigurationService.GetBy(id);
            var variation = await productVariationApplication.GetBy(option.VariationOption.VariationId);
            return new ProductConfigurationViewModel
            {
                Name = variation.Name,
                Value = option.VariationOption.Value
            };
        }
        public async Task<List<ProductConfigurationViewModel>> GetConfigurations(long productItemId)
        {
            var configs = await productConfigurationService.GetConfigsByProductItem(productItemId);
            var view = new List<ProductConfigurationViewModel>();
            configs.ForEach(c => view.Add(Convert(c)));
            return view;
        }
        private ProductConfigurationViewModel Convert(ProductConfiguration c)
        {
            return new ProductConfigurationViewModel
            {
                Name = c.VariationOption.Variation.Name,
                Value = c.VariationOption.Value
            };
        }
    }
}
