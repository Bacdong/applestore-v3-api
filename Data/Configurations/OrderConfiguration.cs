using applestore.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace applestore.Data.Configurations {
    public class OrderConfiguration : IEntityTypeConfiguration<Order> {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder) {
            builder.ToTable("Orders");

            builder.HasKey(x => x.id);
            builder.HasOne(x => x.auth)
                .WithMany(x => x.orders)
                .HasForeignKey(x => x.userId);
        }
    }
}