using BookLibrary.Domain.Core;

namespace BookLibrary.Domain.Entities
{
    public class Book : Entity
    {
        public string Title { get; private set; }
        public int TotalCopies { get; private set; }
        public int CopiesInUse { get; private set; }
        public string Isbn { get; private set; }

        public int TypeId { get; private set; }
        public virtual BookType Type { get; private set; }

        public int CategoryId { get; private set; }
        public virtual BookCategory Category { get; private set; }

        public int AuthorId { get; private set; }
        public virtual Author Author { get; private set; }

        protected Book() { }

        public static Book Create(int id, string title, int totalCopies, int copiesInUse, string isbn, int typeId, int categoryId, int authorId)
        {
            return new()
            {
                Id = id,
                Title = title,
                TotalCopies = totalCopies,
                CopiesInUse = copiesInUse,
                Isbn = isbn,
                TypeId = typeId,
                CategoryId = categoryId,
                AuthorId = authorId
            };
        }
    }
}