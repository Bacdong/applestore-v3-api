using System;
using System.Collections.Generic;
using System.Text;
using applestore.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace applestore.Data.Configurations {
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion> {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Promotion> builder) {
            builder.ToTable("Promotions");

            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.name).IsRequired();
        }
    }
}