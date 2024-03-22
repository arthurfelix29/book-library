using BookLibrary.Domain.Core;

namespace BookLibrary.Domain.Entities
{
	public class Author : Entity
	{
		public string FirstName { get; private set; }
		public string LastName { get; private set; }

        public virtual ICollection<Book> Books { get; private set; }

        protected Author() 
		{
			Books = new HashSet<Book>();
		}

		public static Author Create(int id, string firstName, string lastName)
		{
			return new()
			{
				Id = id,
				FirstName = firstName,
				LastName = lastName
			};
		}

        public override string ToString() => $"{LastName}, {FirstName}";
    }
}