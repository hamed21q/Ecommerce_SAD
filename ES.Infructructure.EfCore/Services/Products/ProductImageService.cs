using ES.Domain.Entities.Products.ProductItemImage;
using ES.Infructructure.EfCore.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Services.Products
{
    public class ProductImageService : Repository<long, ProductImage>, IProductImageService
    {
        public ProductImageService(EcommerceContext context) : base(context)
        {
        }
    }
}
