namespace EShop.Data.Configuration
{
    using Common.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder
                .HasKey(k => new { k.ShoppingCartId, k.ProductId });

            builder
                .HasOne(sc => sc.ShoppingCart)
                .WithMany(sci => sci.ShoppingCartItems)
                .HasForeignKey(sc => sc.ShoppingCartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Product)
                .WithMany(sci => sci.ShoppingCartItems)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
