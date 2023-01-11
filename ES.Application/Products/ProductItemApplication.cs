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
        private readonly IProductConfigurationApplication configurationApplication;

        public ProductItemApplication(
            IProductItemService productItemService,
            IUnitOfWork unitOfWork,
            IProductConfigurationApplication productConfigurationApplication
        )
        {
            this.configurationApplication = productConfigurationApplication;
            this.productItemService = productItemService;
            this.unitOfWork = unitOfWork;
            this.productItemService = productItemService;
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
            configurationApplication.Add(configurationCommands);
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

        public ProductItemViewModel GetBy(long id)
        {
            var item = productItemService.GetBy(id);
            return Convert(item);
        }
        public List<ProductItemViewModel> GetAllSibllings(long productId)
        {
            var items = productItemService.GetAllSibllings(productId);
            var view = new List<ProductItemViewModel>();
            items.ForEach(i => view.Add(Convert(i)));
            return view;

        }
        private ProductItemViewModel Convert(ProductItem item)
        {
            return new ProductItemViewModel
            {
                Id = item.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = item.Price,
                Configurations = configurationApplication.GetConfigurations(item.Id)
            };
        }
    }
}
