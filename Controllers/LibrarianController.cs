
using LibraryManagementSystemEF.Data;
using LibraryManagementSystemEF.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemEF.Controllers
{
    internal class LibrarianController
    {
        public static void Start()
        {
            while (AppController.currentUser != null)
            {
                Console.WriteLine("Welcome to the librarian dashboard!");
                Console.WriteLine("Please enter a number.");
                Console.WriteLine("1. Increment quantity of a book");
                Console.WriteLine("2. View all books");
                Console.WriteLine("3. Sign out");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        IncrementBookQuantity();
                        break;
                    case "2":
                        Console.Clear();
                        AppController.ViewBooks();
                        break;
                    case "3":
                        Console.Clear();
                        AppController.currentUser = null;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        private static void IncrementBookQuantity()
        {
            int pageNumber = 1;
            int pageSize = 5;
            int selectedIndex = 0;
            bool exit = false;

            using (var context = new AppDbContext())
            {
                var totalBooks = context.LibraryBooks
                    .Include(lb => lb.Book)
                    .Where(lb => lb.Book.IsDeleted == false)
                    .Count();

                var totalPages = (int)Math.Ceiling(totalBooks / (double)pageSize);

                if (totalBooks == 0)
                {
                    Console.WriteLine("There are no books.");

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

                    var books = context.LibraryBooks
                        .Include(lb => lb.Book)
                        .Where(lb => lb.Book.IsDeleted == false)
                        .Include(lb => lb.Book.Genre)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

                    Console.WriteLine($"Page {pageNumber}/{totalPages}\n");
                    Console.WriteLine("ID   Title                          Year   Genre               Quantity");
                    Console.WriteLine("-----------------------------------------------------------------------");

                    for (int i = 0; i < books.Count; i++)
                    {
                        if (i == selectedIndex)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }

                        var book = books[i];
                        Console.WriteLine($"{book.BookId}   {book.Book.Title.PadRight(30)}   {book.Book.Year}   {book.Book.Genre.Name.PadRight(10)}   {book.Quantity}");

                        Console.ResetColor();
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

                    Console.WriteLine("\n\nPress <- for previous page, -> for next page. Use ↑/↓ to select a book. Press ENTER to modify, ESC to exit.");

                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.RightArrow:
                            if (pageNumber < totalPages) pageNumber++;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (pageNumber > 1) pageNumber--;
                            break;
                        case ConsoleKey.UpArrow:
                            if (selectedIndex > 0) selectedIndex--;
                            break;
                        case ConsoleKey.DownArrow:
                            if (selectedIndex < books.Count - 1) selectedIndex++;
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            ModifyBookQuantity(books[selectedIndex]);
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            exit = true;
                            break;
                    }
                }
            }
        }

        private static void ModifyBookQuantity(LibraryBook libraryBook)
        {
            if (libraryBook == null) return;

            Console.WriteLine("Modifying Book Quantity\n");
            Console.WriteLine($"Current Quantity: {libraryBook.Quantity}");

            Console.Write("Enter the amount to increment the quantity by: ");
            string incrementInput = Console.ReadLine();

            if (!string.IsNullOrEmpty(incrementInput))
            {
                if (int.TryParse(incrementInput, out int increment))
                {
                    if (increment > 0)
                    {
                        libraryBook.Quantity += increment;

                        using (var context = new AppDbContext())
                        {
                            context.LibraryBooks.Update(libraryBook);
                            context.SaveChanges();
                        }

                        Console.WriteLine($"Book quantity updated successfully. New quantity: {libraryBook.Quantity}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid increment. Please enter a number greater than 0.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("No changes made to the book quantity.");
            }

            Console.WriteLine("Press any key to return.");
            Console.ReadKey();
        }

    }
}
