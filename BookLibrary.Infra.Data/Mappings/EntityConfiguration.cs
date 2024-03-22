using BookLibrary.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.Infra.Data.Mappings
{
    public class EntityConfiguration<TEntity> where TEntity : Entity
    {
        public void DefaultConfigs(EntityTypeBuilder<TEntity> builder, string tableName, bool isDerivedType = false)
        {
            builder.ToTable(tableName);

            if (!isDerivedType)
            {
                builder
                    .Property(entity => entity.Id)
                    .HasColumnName("id");

                builder
                    .HasKey(x => x.Id);
            }
        }
    }
}