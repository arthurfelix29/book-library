using BookLibrary.Domain.Entities;
using BookLibrary.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuProcesso.Infra.Data.Mappings
{
    public class BookTypeMap : EntityConfiguration<BookType>, IEntityTypeConfiguration<BookType>
    {
        public void Configure(EntityTypeBuilder<BookType> builder)
        {
            DefaultConfigs(builder, tableName: "bookType");

            builder
                .Property(booktype => booktype.Description)
                .HasColumnName("description")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}