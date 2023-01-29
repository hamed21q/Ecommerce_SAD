using ES.Application.Contracts.Products.Product;
using ES.Application.Contracts.Products.Product.DTOs;
using ES.Application.Contracts.Products.ProductCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.Product.Validations
{
    public class CreateProductCommandValidation : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidation(IProductCategoryApplication productApplication)
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Image).NotEmpty();
        }
    }
}
