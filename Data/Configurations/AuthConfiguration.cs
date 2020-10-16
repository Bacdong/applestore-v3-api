using System;
using System.Collections.Generic;
using System.Text;
using applestore.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace applestore.Data.Configurations {
    public class AuthConfiguration : IEntityTypeConfiguration<Auth> {
        public void Configure(EntityTypeBuilder<Auth> builder) {
            builder.ToTable("Users");

            builder.Property(x => x.firstName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.lastName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.address).HasMaxLength(200);
        }
    }
}