using BookLibrary.Domain.Core.Interfaces;

namespace BookLibrary.Domain.Core
{
	public abstract class Entity : IEntity
	{
		public int Id { get; protected set; }

		public override bool Equals(object obj)
		{
			var compareTo = obj as Entity;

			if (compareTo is null) return false;
			if (ReferenceEquals(this, compareTo)) return true;

			return Id.Equals(compareTo.Id);
		}

		public static bool operator ==(Entity a, Entity b)
		{
			if (a is null && b is null) return true;
			if (a is null || b is null) return false;

			return a.Equals(b);
		}

		public static bool operator !=(Entity a, Entity b) => !(a == b);
		public override int GetHashCode() => (GetType().GetHashCode() ^ 93) + Id.GetHashCode();
		public override string ToString() => $"{GetType().Name} [Id={Id}]";
	}
}