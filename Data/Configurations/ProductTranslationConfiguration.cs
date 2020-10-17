using applestore.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace applestore.Data.Configurations {
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation> {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProductTranslation> builder) {
            builder.ToTable("ProductTranslations");

            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.seoAlias).IsRequired().HasMaxLength(200);
            builder.Property(x => x.title).HasMaxLength(500);
            builder.Property(x => x.languageId).IsUnicode(false)
                .IsRequired()
                .HasMaxLength(5);

            builder.HasOne(x => x.language)
                .WithMany(x => x.productTranslations)
                .HasForeignKey(x => x.languageId);

            builder.HasOne(x => x.product)
                .WithMany(x => x.productTranslations)
                .HasForeignKey(x => x.productId);
        }
    }
}