﻿using ES.Domain.Entities.ProductConfiguration;
using ES.Infructructure.EfCore.Base;

namespace ES.Infructructure.EfCore.Services
{
    public class ProductConfigurationService : Repository<long, ProductConfiguration>, IProductConfigurationService
    {
        public ProductConfigurationService(EcommerceContext context) : base(context)
        {
        }
    }
}
