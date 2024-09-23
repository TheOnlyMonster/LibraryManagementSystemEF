namespace LibraryManagementSystemEF.Entities
{
    internal class Librarian : User
    {
        public required int Salary { get; set; }

        public required DateTime DateOfEmployment { get; set; } = DateTime.Now;

    }
}
