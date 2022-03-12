namespace EShop.Data.Configuration
{
    using Common.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ProductOptionConfiguration : IEntityTypeConfiguration<ProductOption>
    {
        public void Configure(EntityTypeBuilder<ProductOption> builder)
        {
            builder
                .HasKey(k => new { k.ProductId, k.OptionId});

            builder
                .HasOne(p => p.Product)
                .WithMany(po => po.ProductOptions)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(o => o.Option)
                .WithMany(po => po.ProductOptions)
                .HasForeignKey(o => o.OptionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
