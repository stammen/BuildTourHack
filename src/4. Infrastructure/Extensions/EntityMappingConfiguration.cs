using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Extensions
{
    public abstract class EntityMappingConfiguration<T> : IEntityMappingConfiguration<T> where T : class
    {
        public abstract void Map(EntityTypeBuilder<T> builder);

        public void Map(ModelBuilder modelBuilder)
        {
            Map(modelBuilder.Entity<T>());
        }
    }
}
