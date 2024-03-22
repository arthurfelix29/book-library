using BookLibrary.Domain.Entities;
using BookLibrary.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookLibrary.Infra.Data.Contexts
{
    public class BookLibraryContext : DbContext
    {
        public BookLibraryContext(DbContextOptions<BookLibraryContext> contextOptions) : base(contextOptions)
        { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<BookType> BookTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }
    }
}