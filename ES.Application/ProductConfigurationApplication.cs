using ES.Application.Contracts.ProductConfiguration;
using ES.Domain.DomainService;
using ES.Domain.Entities.ProductConfiguration;

namespace ES.Application
{
    public class ProductConfigurationApplication : IProductConfigurationApplication
    {
        private readonly IProductConfigurationService productConfigurationService;
        private readonly IUnitOfWork unitOfWork;

        public ProductConfigurationApplication(IProductConfigurationService productConfigurationService, 
            IUnitOfWork unitOfWork
        )
        {
            this.productConfigurationService = productConfigurationService;
            this.unitOfWork = unitOfWork;
        }

        public void Add(long productItemId, long variationOptionId)
        {
            var conf = new Domain.Entities.ProductConfiguration.ProductConfiguration(productItemId, variationOptionId);
            productConfigurationService.Add(conf);
            unitOfWork.Save();
        }
        public void Add(List<long> variations, long productItemId) 
        {
            foreach (var item in variations)
            {
                productConfigurationService.Add(new ProductConfiguration(productItemId, item));
            }
            unitOfWork.Save();
        }
    }
}
