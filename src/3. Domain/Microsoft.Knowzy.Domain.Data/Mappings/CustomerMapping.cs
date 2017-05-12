using Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.Knowzy.Domain.Data.Mappings
{
    public class CustomerMapping : EntityMappingConfiguration<Customer>
    {
        public override void Map(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(customer => customer.CompanyName).IsRequired();
            builder.Property(customer => customer.Address).IsRequired();
            builder.Property(customer => customer.ContactPerson).IsRequired();
            builder.Property(customer => customer.Email).IsRequired();
            builder.Property(customer => customer.PhoneNumber).IsRequired();
        }
    }
}
