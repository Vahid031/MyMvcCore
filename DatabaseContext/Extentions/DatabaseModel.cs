using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Attributes;

namespace DatabaseContext.Extentions
{
    public static class DatabaseModel
    {
        public static void AddIndexes(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.GetKeys().ToList().ForEach(key => key.SetIsClustered(false));

                foreach (var prop in entity.GetProperties())
                {
                    var attr = prop.PropertyInfo.GetCustomAttribute<IndexAttribute>();

                    if (attr != null)
                    {
                        var index = entity.AddIndex(prop);
                        index.IsUnique = attr.IsUnique;
                        index.SetIsClustered(attr.IsClustered);
                    }
                }
            }
        }

    }
}