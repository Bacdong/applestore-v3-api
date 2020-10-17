using applestore.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace applestore.Data.Configurations {
    public class LanguageConfiguration : IEntityTypeConfiguration<Language> {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Language> builder) {
            builder.ToTable("Languages");

            builder.HasKey(x => x.id);
            builder.Property(x => x.id)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(5);

            builder.Property(x => x.name).IsRequired().HasMaxLength(20);
        }
    }
}