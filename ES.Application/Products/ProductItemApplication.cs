using ES.Application.Contracts.Products.ProductConfiguration;
using ES.Application.Contracts.Products.ProductConfiguration.DTOs;
using ES.Application.Contracts.Products.ProductImage;
using ES.Application.Contracts.Products.ProductItem;
using ES.Application.Contracts.Products.ProductItem.DTOs;
using ES.Application.Contracts.Products.ProductItem.ViewModels;
using ES.Domain.DomainService;
using ES.Domain.Entities.Products.ProductItem;
using ES.Domain.Entities.Products.ProductItemImage;

namespace ES.Application.Products
{
    public class ProductItemApplication : IProductItemApplication
    {
        private readonly IProductItemService productItemService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductConfigurationApplication configurationApplication;
        private readonly IProductImageService imageService;

        public ProductItemApplication(
            IProductItemService productItemService,
            IUnitOfWork unitOfWork,
            IProductConfigurationApplication productConfigurationApplication
,
            IProductImageService imageService)
        {
            this.configurationApplication = productConfigurationApplication;
            this.productItemService = productItemService;
            this.unitOfWork = unitOfWork;
            this.productItemService = productItemService;
            this.imageService = imageService;
        }

        public async Task Add(CreateProductItemCommand command)
        {
            
            var item = new ProductItem(command.ProductId, command.Quantity, command.Price);
            var images = new List<ProductImage>();
            foreach (var imagedto in command.Images)
            {
                var image = new ProductImage(imagedto.productItemId, imagedto.Image);
                images.Add(image);
            }
            await productItemService.Add(item);
            await unitOfWork.Save();
            foreach (var image in images)
            {
                image.ProductItemId = command.ProductId;
                await imageService.Add(image);
            }
            await AddConfigurations(item.Id, command.configurations);
        }
        public async Task AddImage(CreateProduceImageCommand command)
        {
            await imageService.Add(new ProductImage(command.productItemId, command.Image));
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
            return Convert(item);
        }
        public async Task<List<ProductItemViewModel>> GetAllSibllings(long productId)
        {
            var items = await productItemService.GetAllSibllings(productId);
            var view = new List<ProductItemViewModel>();
            items.ForEach(i => view.Add(Convert(i)));
            return view;
        }
        public async Task RemoveImage(long imageId)
        {
            var image = await imageService.GetBy(imageId);
            productItemService.RemoveImage(image);
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
