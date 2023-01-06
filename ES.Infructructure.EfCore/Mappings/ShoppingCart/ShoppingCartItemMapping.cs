using ES.Domain.Entities.Users.Country;
using ES.Infructructure.EfCore.Mappings.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Mappings.ShoppingCart
{
    public class ShoppingCartItemMapping : EntityTypeConfiguration<ShoppingCartItemMapping>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItemMapping> builder)
        {
            builder.ToTable("ShoppingCartItems");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CartId);
            builder.Property(x => x.ProductItemId);
            builder.Property(x => x.Qty);
        }
    }
}
