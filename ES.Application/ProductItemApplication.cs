using ES.Application.Contracts.Product;
using ES.Application.Contracts.ProductConfiguration;
using ES.Application.Contracts.ProductConfiguration.DTOs;
using ES.Application.Contracts.ProductConfiguration.ViewModel;
using ES.Application.Contracts.ProductItem;
using ES.Application.Contracts.ProductItem.DTOs;
using ES.Application.Contracts.ProductItem.ViewModels;
using ES.Domain.DomainService;
using ES.Domain.Entities.ProductItem;

namespace ES.Application
{
    public class ProductItemApplication : IProductItemApplication
    {
        private readonly IProductItemService productItemService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductApplication productApplication;
        private readonly IProductConfigurationApplication productConfigurationApplication;

        public ProductItemApplication(
            IProductItemService productItemService,
            IUnitOfWork unitOfWork,
            IProductApplication productApplication,
            IProductConfigurationApplication productConfigurationApplication
        )
        {
            this.productConfigurationApplication = productConfigurationApplication;  
            this.productItemService = productItemService;
            this.unitOfWork = unitOfWork;
            this.productApplication = productApplication;
        }

        public void Add(CreateProductItemCommand command)
        {
            var item = new ProductItem(command.ProductId, command.Quantity, command.Price);
            productItemService.Add(item);
            unitOfWork.Save();
            AddConfigurations(item.Id, command.configurations);
        }
        private void AddConfigurations(long itemId, List<long> variationIds)
        {
            var configurationCommands = new List<CreateProductConfigurationCommand>();
            foreach (var vId in variationIds)
            {
                configurationCommands.Add(new CreateProductConfigurationCommand
                {
                    ProductItemId = itemId,
                    VariationOptionId = vId
                });
            }
            productConfigurationApplication.Add(configurationCommands);
        }

        public void Delete(long id)
        {
            var item = productItemService.GetBy(id);
            productItemService.Delete(item);
            unitOfWork.Save();
        }

        public void Edit(EditProductItemCommand command)
        {
            var item = productItemService.GetBy(command.Id);
            item.Edit(command.ProductId, command.Quantity, command.Price);
            unitOfWork.Save();
            
        }

        public List<ProductItemViewModel> GetAll()
        {
            var list = productItemService.GetAll();
            var viewModels = new List<ProductItemViewModel>();
            foreach (var product in list)
            {
                viewModels.Add(new ProductItemViewModel
                {
                    Id = product.Id,
                    Quantity = product.Quantity,
                    Price = product.Price
                });
            }
            return viewModels;
        }

        public ProductItemViewModel GetBy(long id)
        {
            var item = productItemService.GetBy(id);
            var product = productApplication.Convert(item.Product);
            var configurations = new List<ProductConfigurationViewModel>();
            item.Configurations.ForEach(confDomain =>
            {
                var configurationViewModel = productConfigurationApplication.GetBy(confDomain.Id);
                configurations.Add(configurationViewModel);
            });
            
            return new ProductItemViewModel
            {
                Id = id,
                Price = item.Price,
                Product = product,
                Quantity = item.Quantity,
                Configurations = configurations                
            };
        }
    }
}
