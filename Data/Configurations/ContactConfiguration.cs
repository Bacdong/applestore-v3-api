using applestore.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace applestore.Data.Configurations {
    public class ContactConfiguration : IEntityTypeConfiguration<Contact> {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Contact> builder) {
            builder.ToTable("Contacts");

            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.email).HasMaxLength(200).IsRequired();
            builder.Property(x => x.phone).HasMaxLength(200).IsRequired();
            builder.Property(x => x.message).IsRequired();
        }
    }
}