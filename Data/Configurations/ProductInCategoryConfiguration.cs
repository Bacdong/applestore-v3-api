using System;
using System.Collections.Generic;
using System.Text;
using applestore.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace applestore.Data.Configurations {
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory> {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder) {
            builder.ToTable("ProductInCategories");

            builder.HasKey(x => new {x.categoryId, x.productId});

            builder.HasOne(x => x.product)
                .WithMany(pic => pic.productInCategories)
                .HasForeignKey(pic => pic.productId);

            builder.HasOne(x => x.category)
                .WithMany(pic => pic.productInCategories)
                .HasForeignKey(pic => pic.categoryId);
        }
    }
}