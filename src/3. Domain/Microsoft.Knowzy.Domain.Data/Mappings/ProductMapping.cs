using Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.Knowzy.Domain.Data.Mappings
{
    public class ProductMapping : EntityMappingConfiguration<Product>
    {
        public override void Map(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.Id).ValueGeneratedNever();
            builder.Property(product => product.Price).IsRequired();
            builder.Property(product => product.Name).IsRequired();
            builder.Property(product => product.Category).IsRequired();
            builder.Property(product => product.Description).IsRequired();
            builder.Property(product => product.QuantityInStock).IsRequired();
        }
    }
}
