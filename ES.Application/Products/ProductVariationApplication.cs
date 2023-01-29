using ES.Application.Contracts.Products.ProductVariation;
using ES.Application.Contracts.Products.ProductVariation.DTOs;
using ES.Application.Contracts.Products.ProductVariation.ViewModels;
using ES.Domain.DomainService;
using ES.Domain.Entities.Products.ProductVariation;

namespace ES.Application.Products
{
    public class ProductVariationApplication : IProductVariationApplication
    {
        private readonly IProductVariationService productVariationService;
        private readonly IUnitOfWork unitOfWork;


        public ProductVariationApplication(IProductVariationService productVariationService, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.productVariationService = productVariationService;
        }

        public async Task Add(CreateProductVariationCommand command)
        {
            var variation = new ProductVariation(command.CategoryId, command.Name);
            await productVariationService.Add(variation);
            await unitOfWork.Save();
        }

        public async Task Edit(EditProductVariationCommand command)
        {
            var variation = await productVariationService.GetBy(command.Id);
            variation.Edit(command.CategoryId, command.Name);
            await unitOfWork.Save();
        }

        public async Task<List<ProductVariationViewModel>> GetAll()
        {
            var list = await productVariationService.GetAll();
            var view = new List<ProductVariationViewModel>();
            foreach (var item in list)
            {
                view.Add(new ProductVariationViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    CategoryId = item.CategoryId
                });
            }
            return view;
        }

        public async Task<ProductVariationViewModel> GetBy(long id)
        {
            var variation = await productVariationService.GetBy(id);
            return new ProductVariationViewModel
            {
                Id = id,
                Name = variation.Name,
                CategoryId = variation.CategoryId
            };
        }

        public async Task<List<DetailedProductVariationViewModel>> GetByCategory(long categoryId)
        {
            var variations = await productVariationService.GetByCategory(categoryId);
            var view = new List<DetailedProductVariationViewModel>();
            foreach (var item in variations)
            {
                var values = new List<string>();
                item.ProductVariationOptions.ForEach(v => values.Add(v.Value));
                DetailedProductVariationViewModel v = new DetailedProductVariationViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    CategoryId = item.CategoryId,
                    values = values
                };
                view.Add(v);
            }
            return view;
        }

        public async Task<bool> IsValid(long id)
        {
            return await productVariationService.Exist(x => x.Id == id);
        }

        public async Task Remove(long id)
        {
            var variation = await productVariationService.GetBy(id);
            productVariationService.Delete(variation);
            await unitOfWork.Save();
        }
    }
}
