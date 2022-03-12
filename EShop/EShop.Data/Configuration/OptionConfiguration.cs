namespace EShop.Data.Configuration
{
    using Common.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .HasOne(f => f.Filter)
                .WithMany(o => o.Options)
                .HasForeignKey(f => f.FilterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(po => po.ProductOptions)
                .WithOne(o => o.Option)
                .HasForeignKey(o => o.OptionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
