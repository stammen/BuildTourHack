using Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.Knowzy.Domain.Data.Mappings
{
    public class ItemMapping : EntityMappingConfiguration<Item>
    {
        public override void Map(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(item => item.Number);
            builder.Property(item => item.Price).IsRequired();
        }
    }
}
