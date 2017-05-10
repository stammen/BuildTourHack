using Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.Knowzy.Domain.Data.Mappings
{
    public class OrderMapping : EntityMappingConfiguration<Order>
    {
        public override void Map(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.OrderNumber);
            builder.HasDiscriminator<string>("OrderType")
                .HasValue<Shipping>("Shipping")
                .HasValue<Receiving>("Receiving");
            builder.HasOne(order => order.PostalCarrier).WithMany(postalCarrier => postalCarrier.Orders)
                .HasForeignKey(order => order.PostalCarrierId);
            builder.Property(order => order.Email).IsRequired();
            builder.Property(order => order.Address).IsRequired();
            builder.Property(order => order.CompanyName).IsRequired();
            builder.Property(order => order.ContactPerson).IsRequired();
            builder.Property(order => order.PhoneNumber).IsRequired();
            builder.Property(order => order.Tracking).IsRequired();
            builder.Ignore(order => order.Total);
        }
    }
}
