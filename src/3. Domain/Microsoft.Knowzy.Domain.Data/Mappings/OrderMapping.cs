using Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.Knowzy.Domain.Data.Mappings
{
    public class OrderMapping : EntityMappingConfiguration<Order>
    {
        public override void Map(EntityTypeBuilder<Order> builder)
        {
            builder.HasDiscriminator<string>("OrderType")
                .HasValue<Shipping>("Shipping")
                .HasValue<Receiving>("Receiving");
            builder.HasOne(order => order.PostalCarrier)
                .WithMany(postalCarrier => postalCarrier.Orders)
                .HasForeignKey(order => order.PostalCarrierId);
            builder.HasOne(order => order.Customer)
                .WithMany(customer => customer.Orders)
                .HasForeignKey(order => order.CustomerId);
            builder.Property(order => order.Id).ValueGeneratedNever();
            builder.Property(order => order.Tracking).IsRequired();
            builder.Ignore(order => order.Total);
        }
    }
}
