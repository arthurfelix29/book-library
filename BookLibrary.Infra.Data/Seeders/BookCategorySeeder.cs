using BookLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.Infra.Data.Seeders
{
    public static class BookCategorySeeder
    {
        private static readonly List<BookCategory> BookCategories =
        [
            BookCategory.Create(1, "Fiction"),
            BookCategory.Create(2, "Non-Fiction"),
            BookCategory.Create(3, "Biography"),
            BookCategory.Create(4, "Mystery"),
            BookCategory.Create(5, "Sci-Fi")
        ];

        public static void Seed(EntityTypeBuilder<BookCategory> builder)
        {
            builder.HasData(BookCategories);
        }
    }
}