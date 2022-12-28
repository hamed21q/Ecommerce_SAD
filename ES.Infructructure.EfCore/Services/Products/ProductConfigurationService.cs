﻿using ES.Domain.Entities.Products.ProductConfiguration;
using ES.Infructructure.EfCore.Base;

namespace ES.Infructructure.EfCore.Services.Products.Products
{
    public class ProductConfigurationService : Repository<long, ProductConfiguration>, IProductConfigurationService
    {
        public ProductConfigurationService(EcommerceContext context) : base(context)
        {
        }
    }
}