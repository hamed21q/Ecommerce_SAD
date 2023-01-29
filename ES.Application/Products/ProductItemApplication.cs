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

        public async Task Add(CreateProductItemCommand command)
        {
            var item = new ProductItem(command.ProductId, command.Quantity, command.Price);
            await productItemService.Add(item);
            await unitOfWork.Save();
            AddConfigurations(item.Id, command.configurations);
        }
        private async Task AddConfigurations(long itemId, List<long> variationIds)
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
            await configurationApplication.Add(configurationCommands);
        }

        public async Task Delete(long id)
        {
            var item = await productItemService.GetBy(id);
            productItemService.Delete(item);
            await unitOfWork.Save();
        }

        public async Task Edit(EditProductItemCommand command)
        {
            var item = await productItemService.GetBy(command.Id);
            item.Edit(command.ProductId, command.Quantity, command.Price);
            await unitOfWork.Save();

        }

        public async Task<ProductItemViewModel> GetBy(long id)
        {
            var item = await productItemService.GetBy(id);
            return await Convert(item);
        }
        public async Task<List<ProductItemViewModel>> GetAllSibllings(long productId)
        {
            var items = await productItemService.GetAllSibllings(productId);
            var view = new List<ProductItemViewModel>();
            items.ForEach(async i => view.Add(await Convert(i)));
            return view;
        }
        private async Task<ProductItemViewModel> Convert(ProductItem item)
        {
            return new ProductItemViewModel
            {
                Id = item.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = item.Price,
                Configurations = await configurationApplication.GetConfigurations(item.Id)
            };
        }
    }
}
