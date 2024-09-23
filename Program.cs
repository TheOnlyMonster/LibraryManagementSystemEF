using LibraryManagementSystemEF.Data;
using Microsoft.Extensions.Configuration;

namespace LibraryManagementSystemEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
