using BookLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.Infra.Data.Seeders
{
    public static class AuthorSeeder
    {
        private static readonly List<Author> Authors =
        [
            Author.Create(1, "Jane", "Austen"),
            Author.Create(2, "Harper", "Lee"),
            Author.Create(3, "J.D.", "Salinger"),
            Author.Create(4, "F. Scott", "Fitzgerald"),
            Author.Create(5, "Paulo", "Coelho"),
            Author.Create(6, "Markus", "Zusak"),
            Author.Create(7, "C.S.", "Lewis"),
            Author.Create(8, "Dan", "Brown"),
            Author.Create(9, "John", "Steinbeck"),
            Author.Create(10, "Douglas", "Adams"),
            Author.Create(11, "Herman", "Melville")

        ];

        public static void Seed(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(Authors);
        }
    }
}