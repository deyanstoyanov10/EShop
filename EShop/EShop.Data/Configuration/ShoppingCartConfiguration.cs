namespace EShop.Data.Configuration
{
    using Common.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(u => u.AppUser)
                .WithOne(sc => sc.ShoppingCart);

            builder
                .HasMany(sci => sci.ShoppingCartItems)
                .WithOne(sc => sc.ShoppingCart)
                .HasForeignKey(sc => sc.ShoppingCartId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
