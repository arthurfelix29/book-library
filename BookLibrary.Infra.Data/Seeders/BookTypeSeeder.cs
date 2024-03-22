using BookLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.Infra.Data.Seeders
{
    public static class BookTypeSeeder
    {
        private static readonly List<BookType> BookTypes =
        [
            BookType.Create(1, "Hardcover"),
            BookType.Create(2, "Paperback")
        ];

        public static void Seed(EntityTypeBuilder<BookType> builder)
        {
            builder.HasData(BookTypes);
        }
    }
}