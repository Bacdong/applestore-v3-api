using applestore.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace applestore.Data.Configurations {
    public class AuthRoleConfiguration : IEntityTypeConfiguration<AuthRole> {
        public void Configure(EntityTypeBuilder<AuthRole> builder) {
            builder.ToTable("Roles");

            builder.Property(x => x.brief).HasMaxLength(40);
        }
    }
}