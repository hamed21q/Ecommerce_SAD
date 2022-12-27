using ES.Application.Contracts.Products.ProductItem.DTOs;
using ES.Domain.Entities.Products.ProductItem;
using ES.Domain.Entities.Products.ProductVariationOption;
using FluentValidation;
using System.Collections.Generic;

namespace ES.Application.Contracts.Products.ProductItem.Validations
{
    public class CreateProductItemValidation : AbstractValidator<CreateProductItemCommand>
    {
        private readonly IProductItemService productItemService;
        private readonly IProductVariationOptionService productVariationOptionService;

        public CreateProductItemValidation(IProductItemService productItemService, IProductVariationOptionService productVariationOptionService)
        {
            this.productItemService = productItemService;
            this.productVariationOptionService = productVariationOptionService;

            RuleForEach(x => x.configurations).Must(id => productVariationOptionService.Exist(x => x.Id == id));
            RuleFor(x => x.configurations)
                .Must((command, conf) => AllVariationsAreFilled(conf, command.ProductId))
                .WithMessage("no all variations are satesfied").DependentRules(() =>
                {
                    RuleFor(x => x.configurations)
                        .Must((command, conf) => NoDuplicationOption(conf, command.ProductId))
                        .WithMessage("duplicated option for a variation");
                });

        }
        private bool AllVariationsAreFilled(List<long> optiosId, long itemId)
        {
            var filled = new List<long>();
            var must = productItemService.GetProductVariations(itemId);
            optiosId.ForEach(id => filled.Add(productVariationOptionService.GetBy(id).VariationId));
            if (filled.Count < must.Count) return false;
            //check wheather content of filled an must are the same or not
            foreach (var m in must)
            {
                var flag = false;
                foreach (var f in filled)
                {
                    if (f == m) flag = true;
                }
                if (!flag) return false;
            }
            return true;
        }
        private bool NoDuplicationOption(List<long> optiosId, long itemId)
        {
            var filled = new List<long>();
            optiosId.ForEach(id => filled.Add(productVariationOptionService.GetBy(id).VariationId));
            //check if there is duplicated record in filled
            for (int i = 0; i < filled.Count; i++)
            {
                for (int j = 0; j < filled.Count; j++)
                {
                    if (i != j && filled[i] == filled[j]) return false;
                }
            }
            return true;
        }
    }
}
