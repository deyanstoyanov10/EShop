namespace EShop.Data.Configuration
{
    using Common.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .HasOne(p => p.Product)
                .WithMany(p => p.Pictures)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
