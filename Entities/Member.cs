namespace LibraryManagementSystemEF.Entities
{
    internal class Member : User
    {
        public DateTime DateOfMembership { get; set; } = DateTime.Now;

        public int MembershipDuration { get; set; }

        public ICollection<BorrowedBook> BorrowedBooks { get; set; } = [];

    }
}
