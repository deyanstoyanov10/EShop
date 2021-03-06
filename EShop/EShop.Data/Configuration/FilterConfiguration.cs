namespace EShop.Data.Configuration
{
    using Common.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class FilterConfiguration : IEntityTypeConfiguration<Filter>
    {
        public void Configure(EntityTypeBuilder<Filter> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .HasOne(c => c.Category)
                .WithMany(f => f.Filters)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(o => o.Options)
                .WithOne(f => f.Filter)
                .HasForeignKey(f => f.FilterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
