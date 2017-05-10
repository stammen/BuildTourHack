using Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.Knowzy.Domain.Data.Mappings
{
    public class OrderLineMapping : EntityMappingConfiguration<OrderLine>
    {
        public override void Map(EntityTypeBuilder<OrderLine> builder)
        {
            builder.HasOne(orderLine => orderLine.Item).WithMany(item => item.OrderLines)
                .HasForeignKey(orderLine => orderLine.ItemNumber);
            builder.HasOne(orderLine => orderLine.Order)
                .WithMany(order => order.OrderLines)
                .HasForeignKey(orderLine => orderLine.OrderNumber);
            builder.Property(orderLine => orderLine.Quantity).IsRequired();
            builder.Property(orderLine => orderLine.Price).IsRequired();
        }
    }
}
