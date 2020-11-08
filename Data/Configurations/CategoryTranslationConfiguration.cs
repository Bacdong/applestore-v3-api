using applestore.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace applestore.Data.Configurations
{
    public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation> {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CategoryTranslation> builder) {
            builder.ToTable("CategoryTranslations");

            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.slug).IsRequired().HasMaxLength(200);
            builder.Property(x => x.brief).HasMaxLength(500);
            builder.Property(x => x.title).HasMaxLength(200);
            builder.Property(x => x.languageId).IsUnicode(false)
                .IsRequired()
                .HasMaxLength(5);

            builder.HasOne(x => x.language)
                .WithMany(x => x.categoryTranslations)
                .HasForeignKey(x => x.languageId);

            builder.HasOne(x => x.category)
                .WithMany(x => x.categoryTranslations)
                .HasForeignKey(x => x.categoryId);
        }
    }
}