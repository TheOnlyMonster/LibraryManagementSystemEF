namespace LibraryManagementSystemEF.Entities
{
    internal class Author : User
    {
        public string Biography { get; set; }

        public ICollection<Book> Books { get; set; } = [];

        public override string ToString()
        {
            return Name;
        }
    }
}
