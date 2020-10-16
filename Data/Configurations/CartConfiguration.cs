using System;
using System.Collections.Generic;
using System.Text;
using applestore.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace applestore.Data.Configurations {
    public class CartConfiguration : IEntityTypeConfiguration<Cart> {
        public void Configure(EntityTypeBuilder<Cart> builder) {
            builder.ToTable("Carts");

            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            
            builder.HasOne(x => x.product)
                .WithMany(x => x.carts)
                .HasForeignKey(x => x.productId);

            builder.HasOne(x => x.auth)
                .WithMany(x => x.carts)
                .HasForeignKey(x => x.userId);
        }
    }
}