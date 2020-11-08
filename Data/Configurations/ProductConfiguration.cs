using System;
using applestore.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace applestore.Data.Configurations {
    public class ProductConfiguration : IEntityTypeConfiguration<Product> {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder) {
            builder.ToTable("Products");

            builder.HasKey(x => x.id);
            builder.Property(x => x.price).IsRequired();
            builder.Property(x => x.originalPrice).IsRequired();
            builder.Property(x => x.inventory).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.viewCount).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.created).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.updated).HasDefaultValue(DateTime.UtcNow);
        }
    }
}