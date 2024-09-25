using LibraryManagementSystemEF.Data;
using LibraryManagementSystemEF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemEF.Controllers
{
    internal static class AppController
    {
        public static User? currentUser;

        public static void Start()
        {
            Console.WriteLine("Welcome to our Library Management System console application!");


            while (currentUser == null)
            {
                Console.WriteLine("Please enter a number.");
                Console.WriteLine("1. Sign up");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("3. View Books");
                Console.WriteLine("4. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        SignUp();
                        break;
                    case "2":
                        Console.Clear();
                        SignIn();
                        break;
                    case "3":
                        Console.Clear();
                        ViewBooks();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }

            if (currentUser is Member)
            {
                Console.Clear();
                MemberController.Start();
            }else if (currentUser is Author)
            {
                Console.Clear();
                AuthorController.Start();
            }

        }

        public static void SignUp()
        {
            Console.WriteLine("Please enter your first name");
            var firstName = Console.ReadLine();

            Console.WriteLine("Please enter your last name");
            var lastName = Console.ReadLine();

            Console.WriteLine("Please enter your email");
            var email = Console.ReadLine();

            Console.WriteLine("Please enter your password");
            var password = Console.ReadLine();

            Console.WriteLine("Please enter your desired membership duration (days)");
            var membershipDuration = int.Parse(Console.ReadLine());


            var member = new Member
            {
                Email = email,
                Password = password,
                Name = firstName + " " + lastName,
                MembershipDuration = membershipDuration
            };

            using (var context = new AppDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Email == email);

                if (user != null)
                {
                    Console.WriteLine("User with this email already exists");
                    return;
                }

                context.Users.Add(member);

                context.SaveChanges();

                Console.WriteLine("Member created successfully");
            }
        }

        public static void SignIn()
        {
            Console.WriteLine("Please enter your email");
            var email = Console.ReadLine();

            Console.WriteLine("Please enter your password");
            var password = Console.ReadLine();

            using (var context = new AppDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

                if (user == null)
                {
                    Console.WriteLine("Invalid email or password");
                }
                else
                {
                    currentUser = user;

                    Console.WriteLine("Welcome " + user.Name);

                }
            }
        }

        public static void ViewBooks()
        {
            int pageNumber = 1;
            int pageSize = 5;
            bool exit = false;

            using (var context = new AppDbContext())
            {
                var allBooks = context.Books.Where(b => b.IsDeleted == false).Count();

                var totalPages = (int)Math.Ceiling(allBooks / (double)pageSize);

                if(allBooks == 0)
                {
                    Console.WriteLine("No books available");
                    for (int i = 5; i > 0; i--)
                    {
                        Console.WriteLine($"Exiting in {i} seconds...");

                        Thread.Sleep(1000);
                    }

                    return;
                }

                while (!exit)
                {
                    Console.Clear();

                    var books = context.Books
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .Where(b => b.IsDeleted == false)
                        .Include(b => b.Genre)
                        .Include(b => b.Author);

                    Console.WriteLine($"Page {pageNumber}/{totalPages}\n");
                    Console.WriteLine("ID   Title                          Year   Genre             Author");
                    Console.WriteLine("-----------------------------------------------------------------------");

                    foreach (var book in books)
                    {
                        Console.WriteLine($"{book.Id.ToString().PadRight(4)} {book.Title.PadRight(30)} {book.Year.ToString().PadRight(6)} {(book.Genre?.ToString() ?? "Unknown").PadRight(15)} {book.Author?.ToString() ?? "Unknown"}");
                    }

                    Console.WriteLine("\nPages:");
                    for (int i = 1; i <= totalPages; i++)
                    {
                        if (i == pageNumber)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"[{i}] ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write($"{i} ");
                            Console.ResetColor();
                        }
                    }

                    Console.WriteLine("\n\nPress <- for previous page, -> for next page. Press ESC to exit.");

                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.RightArrow:
                            if (pageNumber < totalPages) pageNumber++;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (pageNumber > 1) pageNumber--;
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            exit = true;
                            break;
                    }
                }
            }
        }
    }
}
