﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Domain.Entities.Products.ProductVariationOption;

namespace ES.Domain.Entities.Products.ProductConfiguration
{
    public class ProductConfiguration : BaseDomain
    {
        public long ProductItemId { get; private set; }
        public long VariationOptionId { get; private set; }

        //navigation
        public virtual ProductItem.ProductItem ProductItem { get; private set; }
        public virtual ProductVariationOption.ProductVariationOption VariationOption { get; private set; }
        public ProductConfiguration(long productItemId, long variationOptionId) : base()
        {
            ProductItemId = productItemId;
            VariationOptionId = variationOptionId;
        }
        public void Edit(long productItemId, long variationOptionId)
        {
            ProductItemId = productItemId;
            VariationOptionId = variationOptionId;
        }
    }
}
