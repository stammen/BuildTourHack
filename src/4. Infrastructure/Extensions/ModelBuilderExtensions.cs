using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddEntityConfigurationsFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var mappingTypes = assembly.GetMappingTypes(typeof(IEntityMappingConfiguration<>));

            foreach (var config in mappingTypes.Select(Activator.CreateInstance).Cast<IEntityMappingConfiguration>())
            {
                config.Map(modelBuilder);
            }
        }

        private static IEnumerable<Type> GetMappingTypes(this Assembly assembly, Type mappingInterface)
        {
            return assembly
                .GetTypes()
                .Where(type => !type.GetTypeInfo().IsAbstract &&
                    type.GetInterfaces().Any(inter => inter.GetTypeInfo().IsGenericType 
                                             && inter.GetGenericTypeDefinition() == mappingInterface));
        }
    }
}
