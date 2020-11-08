using System;
using applestore.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace applestore.Data.Configurations {
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage> {
        public void Configure(EntityTypeBuilder<ProductImage> builder) {
            builder.ToTable("ProductImages");

            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.imagePath).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.created).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.updated).HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(x => x.product)
                .WithMany(x => x.productImages)
                .HasForeignKey(x => x.productId);
        }
    }
}