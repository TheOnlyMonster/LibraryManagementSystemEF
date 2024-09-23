namespace LibraryManagementSystemEF.Entities
{
    internal class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public Genre Genre { get; set; } 

        public int? GenreId { get; set; } 

        public int AuthorId { get; set; }

        public Author Author { get; set; }

    }
}
