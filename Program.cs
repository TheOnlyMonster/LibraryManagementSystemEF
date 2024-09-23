using LibraryManagementSystemEF.Controllers;
using LibraryManagementSystemEF.Data;
using LibraryManagementSystemEF.Entities;
using Microsoft.Extensions.Configuration;

namespace LibraryManagementSystemEF
{
    internal class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                AppController.Start();
            }

        }

        
    }
}
