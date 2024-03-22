namespace BookLibrary.Application.Dtos
{
    public class BookDto
    {
        public string Title { get; private set; }
        public int TotalCopies { get; private set; }
        public int CopiesInUse { get; private set; }
        public string Isbn { get; private set; }
        public string Author { get; private set; }
        public string Type { get; private set; }
        public string Category { get; private set; }

        internal BookDto() { }

        public BookDto(string title, int totalCopies, int copiesInUse, string isbn, string author, string type, string category)
        {
            Title = title;
            TotalCopies = totalCopies;
            CopiesInUse = copiesInUse;
            Isbn = isbn;
            Author = author;
            Type = type;
            Category = category;
        }
    }
}