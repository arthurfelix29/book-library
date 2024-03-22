using BookLibrary.Domain.Entities;
using BookLibrary.Infra.Data.Seeders;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Infra.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.SeedBookCategory();
            builder.SeedBookType();
            builder.SeedAuthor();
            builder.SeedBook();
        }

        private static void SeedBookCategory(this ModelBuilder builder)
        {
            BookCategorySeeder.Seed(builder.Entity<BookCategory>());
        }

        private static void SeedBookType(this ModelBuilder builder)
        {
            BookTypeSeeder.Seed(builder.Entity<BookType>());
        }

        private static void SeedAuthor(this ModelBuilder builder)
        {
            AuthorSeeder.Seed(builder.Entity<Author>());
        }

        private static void SeedBook(this ModelBuilder builder)
        {
            BookSeeder.Seed(builder.Entity<Book>());
        }
    }
}