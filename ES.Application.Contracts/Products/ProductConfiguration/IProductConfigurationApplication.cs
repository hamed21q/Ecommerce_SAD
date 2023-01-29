using ES.Application.Contracts.Products.ProductConfiguration.DTOs;
using ES.Application.Contracts.Products.ProductConfiguration.ViewModel;
using ES.Domain.Entities.Products.ProductConfiguration;

namespace ES.Application.Contracts.Products.ProductConfiguration
{
    public interface IProductConfigurationApplication
    {
        Task Add(List<CreateProductConfigurationCommand> variations);
        Task Edit(long id, long productItemId, long variationOptionId);
        Task<ProductConfigurationViewModel> GetBy(long id);
        Task<List<ProductConfigurationViewModel>> GetConfigurations(long productItemId);
    }
}
