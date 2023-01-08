using ES.Infructructure.EfCore.Mappings.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ES.Infructructure.EfCore.Mappings.ShoppingCart
{
    public class ShoppingCartMapping : EntityTypeConfiguration<Domain.Entities.ShoppingCart.ShoppingCart.ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.ShoppingCart.ShoppingCart.ShoppingCart> builder)
        {
            builder.ToTable("shoppingCarts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId);

            builder.HasOne(x => x.User).WithMany(x => x.ShoppingCarts).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
