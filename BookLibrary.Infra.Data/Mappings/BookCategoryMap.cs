using BookLibrary.Domain.Entities;
using BookLibrary.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuProcesso.Infra.Data.Mappings
{
    public class BookCategoryMap : EntityConfiguration<BookCategory>, IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            DefaultConfigs(builder, tableName: "bookCategory");

            builder
                .Property(bookCategory => bookCategory.Description)
                .HasColumnName("description")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}