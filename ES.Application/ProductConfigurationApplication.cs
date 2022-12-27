using ES.Application.Contracts.ProductConfiguration;
using ES.Application.Contracts.ProductConfiguration.DTOs;
using ES.Application.Contracts.ProductConfiguration.ViewModel;
using ES.Application.Contracts.ProductVariation;
using ES.Domain.DomainService;
using ES.Domain.Entities.ProductConfiguration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace ES.Application
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
    }
}
