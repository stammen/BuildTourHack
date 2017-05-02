using Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.Knowzy.Domain.Data.Mappings
{
    public class OrderLineMapping : EntityMappingConfiguration<OrderLine>
    {
        public override void Map(EntityTypeBuilder<OrderLine> builder)
        {
            builder.HasOne(orderLine => orderLine.Item);
            builder.Property(orderLine => orderLine.Quantity).IsRequired();
            builder.Property(orderLine => orderLine.Price).IsRequired();
        }
    }
}
