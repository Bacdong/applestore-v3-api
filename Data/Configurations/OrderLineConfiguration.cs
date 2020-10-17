using applestore.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace applestore.Data.Configurations {
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine> {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderLine> builder) {
            builder.ToTable("OrderLines");

            builder.HasKey(x => new {x.orderId, x.productId});
            builder.HasOne(x => x.order)
                .WithMany(x => x.orderLines)
                .HasForeignKey(x => x.orderId);
            
            builder.HasOne(x => x.product)
                .WithMany(x => x.orderLines)
                .HasForeignKey(x => x.productId);
        }
    }
}