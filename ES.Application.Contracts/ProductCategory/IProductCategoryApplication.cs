﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        void Add(CreateProductCategoryCommand command);
        List<ProductCategoryViewModel> GetAll();
    }
}