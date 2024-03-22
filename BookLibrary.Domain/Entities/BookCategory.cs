using BookLibrary.Domain.Core;

namespace BookLibrary.Domain.Entities
{
    public class BookCategory : Entity
    {
        public string Description { get; private set; }

        public virtual Book Book { get; private set; }

        protected BookCategory() { }

        public static BookCategory Create(int id, string description)
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