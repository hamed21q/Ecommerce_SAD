using ES.Application.Contracts.Product;
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

        public ProductItemApplication(IProductItemService productItemService,
            IUnitOfWork unitOfWork,
            IProductApplication productApplication
        )
        {
            this.productItemService = productItemService;
            this.unitOfWork = unitOfWork;
            this.productApplication = productApplication;
        }

        public void Add(CreateProductItemCommand command)
        {
            var item = new ProductItem(command.ProductId, command.Quantity, command.Price);
            productItemService.Add(item);
            unitOfWork.Save();
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
            var product = productApplication.Convert(item.Product);
            return new ProductItemViewModel
            {
                Id = id,
                Price = item.Price,
                Product = product,
                Quantity = item.Quantity,
            };
        }
    }
}
