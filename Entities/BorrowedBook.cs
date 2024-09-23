namespace LibraryManagementSystemEF.Entities
{
    internal class BorrowedBook
    {
        public int Id { get; set; }

        public Book BookDetails { get; set; }

        public int? BookDetailsId { get; set; }

        public Member Member { get; set; }

        public int MemberId { get; set; }

        public string TitleSnapshot { get; set; }

        public int YearSnapshot { get; set; }

        public string GenreSnapshot { get; set; }

        public DateTime BorrowDate { get; set; } = DateTime.Now;

        public DateTime ReturnDate { get; set; }

        public bool IsReturned { get; set; }
    }
}
