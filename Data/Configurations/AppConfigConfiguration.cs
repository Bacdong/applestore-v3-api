using System;
using System.Collections.Generic;
using System.Text;
using applestore.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace applestore.Data.Configurations {
    public class AppConfigConfiguration : IEntityTypeConfiguration<AppConfig> {
        public void Configure(EntityTypeBuilder<AppConfig> builder) {
            builder.ToTable("AppConfigs");

            builder.HasKey(x => x.key);
            builder.Property(x => x.value).IsRequired();
        }
    }
}