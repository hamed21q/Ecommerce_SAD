using ES.Application.Contracts.Products.ProductVariationOption.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.ProductVariationOption.Validations
{
    public class CreateProductVariatioOptionValidation : AbstractValidator<CreateProductVariationOptionCommand>
    {
        public CreateProductVariatioOptionValidation()
        {

        }
    }
}
