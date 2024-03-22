using BookLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.Infra.Data.Seeders
{
    public static class BookSeeder
    {
        private static readonly List<Book> Books =
        [
            Book.Create(1, "Pride and Prejudice", 100, 80, "1234567891", 1, 1, 1),
            Book.Create(2, "To Kill a Mockingbird", 75, 65, "1234567892", 2, 1, 2),
            Book.Create(3, "The Catcher in the Rye", 50, 45, "1234567893", 1, 1, 3),
            Book.Create(4, "The Great Gatsby", 50, 22, "1234567894", 1, 2, 4),
            Book.Create(5, "The Alchemist", 50, 35, "1234567895", 1, 3, 5),
            Book.Create(6, "The Book Thief", 75, 11, "1234567896", 1, 4, 6),
            Book.Create(7, "The Chronicles of Narnia", 100, 14, "1234567897", 2, 5, 7),
            Book.Create(8, "The Da Vinci Code", 50, 40, "1234567898", 2, 5, 8),
            Book.Create(9, "The Grapes of Wrath", 50, 35, "1234567899", 1, 1, 9),
            Book.Create(10, "The Hitchhiker's Guide to the Galaxy", 50, 35, "1234567900", 2, 2, 10),
            Book.Create(11, "Moby-Dick", 30, 8, "8901234567", 1, 1, 11),
            Book.Create(12, "To Kill a Mockingbird", 20, 0, "9012345678", 2, 2, 2),
            Book.Create(13, "The Catcher in the Rye", 10, 1, "0123456789", 1, 2, 3)
        ];

        public static void Seed(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(Books);
        }
    }
}