using BookLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.Infra.Data.Mappings
{
    public class BookMap : EntityConfiguration<Book>, IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            DefaultConfigs(builder, tableName: "book");

            builder
                .Property(book => book.Title)
                .HasColumnName("title")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(book => book.TotalCopies)
                .HasColumnName("total_copies")
                .HasDefaultValue(0)
                .IsRequired();

            builder
                .Property(book => book.CopiesInUse)
                .HasColumnName("copies_in_use")
                .HasDefaultValue(0)
                .IsRequired();

            builder
                .HasOne(book => book.Type)
                .WithOne(bookType => bookType.Book)
                .HasForeignKey<Book>(book => book.TypeId);

            builder
                .Property(book => book.Isbn)
                .HasColumnName("isbn")
                .HasMaxLength(80);

            builder
                .HasOne(book => book.Category)
                .WithOne(bookCategory => bookCategory.Book)
                .HasForeignKey<Book>(book => book.CategoryId);

            builder
               .Property(book => book.TypeId)
               .HasColumnName("type_id");

            builder
               .Property(book => book.CategoryId)
               .HasColumnName("category_id");

            builder
                .Property(book => book.AuthorId)
                .HasColumnName("author_id");
        }
    }
}