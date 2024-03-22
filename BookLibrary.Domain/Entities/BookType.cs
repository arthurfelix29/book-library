using BookLibrary.Domain.Core;

namespace BookLibrary.Domain.Entities
{
    public class BookType : Entity
    {
        public string Description { get; private set; }

        public virtual Book Book { get; private set; }

        protected BookType() { }

        public static BookType Create(int id, string description)
        {
            return new()
            {
                Id = id,
                Description = description
            };
        }

        public override string ToString() => Description;
    }
}