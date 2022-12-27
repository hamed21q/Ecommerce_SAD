using ES.Application.Contracts.ProductConfiguration.DTOs;
using ES.Application.Contracts.ProductConfiguration.ViewModel;
using ES.Domain.Entities.ProductConfiguration;

namespace ES.Application.Contracts.ProductConfiguration
{
    public interface IProductConfigurationApplication
    {
        void Add(List<CreateProductConfigurationCommand> variations);
        void Edit(long id,long productItemId, long variationOptionId);
        ProductConfigurationViewModel GetBy(long id);
    }
}
