using System.Reflection;
using Extensions;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Knowzy.Domain.Data
{
    public class KnowzyContext : DbContext, IUnitOfWork
    {
        public KnowzyContext(DbContextOptions options) : base(options) { }

        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Receiving> Receivings { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<PostalCarrier> PostalCarriers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().GetTypeInfo().Assembly);
        }
    }
}
