using Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.Knowzy.Domain.Data.Mappings
{
    public class PostalCarrierMapping : EntityMappingConfiguration<PostalCarrier>
    {
        public override void Map(EntityTypeBuilder<PostalCarrier> builder)
        {
            builder.Property(postalCarrier => postalCarrier.Id).ValueGeneratedNever();
            builder.Property(postalCarrier => postalCarrier.Name).IsRequired();
        }
    }
}
