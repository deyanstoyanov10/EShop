namespace EShop.Data.Configuration
{
    using Common.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(p => p.Pictures)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(po => po.ProductOptions)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
