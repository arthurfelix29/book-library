using System.Reflection;

namespace BookLibrary.Domain.Core
{
	public abstract record Enumeration<T> : IComparable<T> where T : Enumeration<T>
	{
		private static readonly Lazy<Dictionary<int, T>> _allItems;
		private static readonly Lazy<Dictionary<string, T>> _allItemsByName;

		static Enumeration()
		{
			_allItems = new Lazy<Dictionary<int, T>>(() =>
			{
				return typeof(T)
					.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
					.Where(fieldInfo => fieldInfo.FieldType == typeof(T))
					.Select(fieldInfo => fieldInfo.GetValue(null))
					.Cast<T>()
					.ToDictionary(x => x.Value, x => x);
			});

			_allItemsByName = new Lazy<Dictionary<string, T>>(() =>
			{
				var items = new Dictionary<string, T>(_allItems.Value.Count);

				foreach (var item in _allItems.Value)
					if (!items.TryAdd(item.Value.DisplayName, item.Value))
						throw new Exception($"DisplayName needs to be unique. '{item.Value.DisplayName}' already exists");

				return items;
			});
		}

		//default ctor for EF
		protected Enumeration() { }

		protected Enumeration(int value, string displayName)
		{
			Value = value;
			DisplayName = displayName;
		}

		public int Value { get; }
		public string DisplayName { get; }

		public override string ToString() => DisplayName;
		public static IEnumerable<T> GetAll() => _allItems.Value.Values;
		public static int AbsoluteDifference(Enumeration<T> firstValue, Enumeration<T> secondValue) => Math.Abs(firstValue.Value - secondValue.Value);

		public static T FromValue(int value)
		{
			if (_allItems.Value.TryGetValue(value, out var matchingItem))
				return matchingItem;

			throw new InvalidOperationException($"'{value}' is not a valid value in {typeof(T)}");
		}

		public static T FromDisplayName(string displayName)
		{
			if (_allItemsByName.Value.TryGetValue(displayName, out var matchingItem))
				return matchingItem;

			throw new InvalidOperationException($"'{displayName}' is not a valid display name in {typeof(T)}");
		}

		public int CompareTo(T? other) => Value.CompareTo(other!.Value);
	}
}