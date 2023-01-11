using ES.Application.Contracts.Products.ProductConfiguration.DTOs;
using ES.Application.Contracts.Products.ProductConfiguration.ViewModel;
using ES.Domain.Entities.Products.ProductConfiguration;

namespace ES.Application.Contracts.Products.ProductConfiguration
{
    public interface IProductConfigurationApplication
    {
        void Add(List<CreateProductConfigurationCommand> variations);
        void Edit(long id, long productItemId, long variationOptionId);
        ProductConfigurationViewModel GetBy(long id);
        List<ProductConfigurationViewModel> GetConfigurations(long productItemId);
    }
}
