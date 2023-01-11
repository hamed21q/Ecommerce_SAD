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

        public void Add(List<CreateProductConfigurationCommand> variations)
        {
            foreach (var item in variations)
            {
                productConfigurationService.Add(new ProductConfiguration(item.ProductItemId, item.VariationOptionId));
            }
            unitOfWork.Save();
        }

        public void Edit(long id, long productItemId, long variationOptionId)
        {
            var conf = productConfigurationService.GetBy(id);
            conf.Edit(productItemId, variationOptionId);
            unitOfWork.Save();
        }

        public ProductConfigurationViewModel GetBy(long id)
        {
            var option = productConfigurationService.GetBy(id);
            var variation = productVariationApplication.GetBy(option.VariationOption.VariationId);
            return new ProductConfigurationViewModel
            {
                Name = variation.Name,
                Value = option.VariationOption.Value
            };
        }
        public List<ProductConfigurationViewModel> GetConfigurations(long productItemId)
        {
            var configs = productConfigurationService.GetConfigsByProductItem(productItemId);
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
