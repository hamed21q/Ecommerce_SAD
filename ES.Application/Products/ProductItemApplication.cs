using ES.Application.Contracts.Products.Product;
using ES.Application.Contracts.Products.ProductConfiguration;
using ES.Application.Contracts.Products.ProductConfiguration.DTOs;
using ES.Application.Contracts.Products.ProductConfiguration.ViewModel;
using ES.Application.Contracts.Products.ProductItem;
using ES.Application.Contracts.Products.ProductItem.DTOs;
using ES.Application.Contracts.Products.ProductItem.ViewModels;
using ES.Domain.DomainService;
using ES.Domain.Entities.Products.Product;
using ES.Domain.Entities.Products.ProductItem;

namespace ES.Application.Products
{
    public class ProductItemApplication : IProductItemApplication
    {
        private readonly IProductItemService productItemService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductService productService;
        private readonly IProductConfigurationApplication productConfigurationApplication;

        public ProductItemApplication(
            IProductItemService productItemService,
            IUnitOfWork unitOfWork,
            IProductService productService,
            IProductConfigurationApplication productConfigurationApplication
        )
        {
            this.productConfigurationApplication = productConfigurationApplication;
            this.productItemService = productItemService;
            this.unitOfWork = unitOfWork;
            this.productItemService = productItemService;
            this.productService = productService;
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
                viewModels.Add(Convert(product));
            }
            return viewModels;
        }

        public ProductItemViewModel GetBy(long id)
        {
            var item = productItemService.GetBy(id);
            return Convert(item);
        }

        public ProductItemViewModel Convert(ProductItem item)
        {
            var product = productService.GetBy(item.ProductId);
            var configurations = new List<ProductConfigurationViewModel>();
            item.Configurations.ForEach(confDomain =>
            {
                var configurationViewModel = productConfigurationApplication.GetBy(confDomain.Id);
                configurations.Add(configurationViewModel);
            });

            return new ProductItemViewModel
            {
                Id = item.Id,
                ProductId = item.ProductId,
                Price = item.Price,
                Quantity = item.Quantity,
                Configurations = configurations
            };
        }
    }
}
