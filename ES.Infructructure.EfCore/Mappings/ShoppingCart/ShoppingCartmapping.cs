using ES.Domain.Entities.Users.User;
using ES.Infructructure.EfCore.Mappings.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Mappings.ShoppingCart
{
    public class ShoppingCartmapping : EntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("shoppingCarts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId);

            builder.HasOne(x => x.SiteUser).WithMany(x => x.ShoppingCart).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
