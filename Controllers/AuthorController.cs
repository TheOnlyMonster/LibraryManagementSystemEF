
using LibraryManagementSystemEF.Data;
using LibraryManagementSystemEF.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemEF.Controllers
{
    internal class AuthorController
    {
        public static void Start()
        {
            while(AppController.currentUser != null)
            {
                Console.WriteLine("Welcome to the author dashboard!");
                Console.WriteLine("Please enter a number.");
                Console.WriteLine("1. Add a new book");
                Console.WriteLine("2. View all books");
                Console.WriteLine("3. View published books");
                Console.WriteLine("4. Sign out");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        AddBook();
                        break;
                    case "2":
                        Console.Clear();
                        AppController.ViewBooks();
                        break;
                    case "3":
                        Console.Clear();
                        ViewPublishedBooks();
                        break;
                    case "4":
                        Console.Clear();
                        AppController.currentUser = null;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        private static void ViewPublishedBooks()
        {
            int pageNumber = 1;
            int pageSize = 5;
            int selectedIndex = 0;
            bool exit = false;

            using (var context = new AppDbContext())
            {
                var totalBooks = context.Books
                    .Where(b => b.AuthorId == AppController.currentUser.Id && b.IsDeleted == false)
                    .Count();

                var totalPages = (int)Math.Ceiling(totalBooks / (double)pageSize);

                if (totalBooks == 0)
                {
                    Console.WriteLine("There are no published books.");

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
                        .Where(b => b.AuthorId == AppController.currentUser.Id && b.IsDeleted == false)
                        .Include(b => b.Genre)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

                    Console.WriteLine($"Page {pageNumber}/{totalPages}\n");
                    Console.WriteLine("ID   Title                          Year   Genre");
                    Console.WriteLine("-----------------------------------------------------------------------");

                    for (int i = 0; i < books.Count; i++)
                    {
                        if (i == selectedIndex)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }

                        var book = books[i];
                        Console.WriteLine($"{book.Id}   {book.Title.PadRight(30)}   {book.Year}   {book.Genre.Name}");

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
                            ModifyBookDetails(books[selectedIndex]); 
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            exit = true;
                            break;
                    }
                }
            }
        }

        private static void ModifyBookDetails(Book book)
        {
            Console.Clear();
            Console.WriteLine("Modifying Book Details\n");
            Console.WriteLine($"Current Title: {book.Title}");
            Console.Write("Enter new Title (leave blank to keep current): ");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrEmpty(newTitle))
            {
                book.Title = newTitle;
            }

            Console.WriteLine($"Current Year: {book.Year}");
            Console.Write("Enter new Year (leave blank to keep current): ");
            string newYearInput = Console.ReadLine();
            if (int.TryParse(newYearInput, out int newYear))
            {
                book.Year = newYear;
            }

            Console.WriteLine($"Current Genre: {book.Genre.Name}");
            Console.Write("Enter new Genre (leave blank to keep current): ");
            string newGenre = Console.ReadLine();
            


            using (var context = new AppDbContext())
            {
                using var transaction = context.Database.BeginTransaction();

                try
                {
                    if (!string.IsNullOrEmpty(newGenre))
                    {
                        var genreExists = context.Genres.FirstOrDefault(g => g.Name.ToLower() == newGenre.ToLower());

                        if (genreExists == null)
                        {
                            genreExists = new Genre
                            {
                                Name = newGenre
                            };

                            context.Genres.Add(genreExists);

                            context.SaveChanges();

                        }


                        book.GenreId = genreExists.Id;
                        book.Genre = genreExists;

                        context.SaveChanges();
                    }

                    context.Books.Update(book);
                    context.SaveChanges();

                    transaction.Commit();

                    Console.WriteLine("Book details updated successfully. Press any key to return.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    Console.WriteLine(ex.Message);
                }
            }
            
            Console.ReadKey();
        }

        private static void AddBook()
        {
            if (AppController.currentUser == null) { return; }

            using (var context = new AppDbContext())
            {
                Console.WriteLine("Enter the title of the book:");
                var title = Console.ReadLine();

                Console.WriteLine("Enter the genre of the book:");
                var genre = Console.ReadLine();


                Console.WriteLine("Enter the year of the book:");
                var year = int.Parse(Console.ReadLine());


                using var transaction = context.Database.BeginTransaction();

                try
                {
                    var genreExists = context.Genres.FirstOrDefault(g => g.Name.ToLower() == genre.ToLower());

                    if (genreExists == null)
                    {
                        genreExists = new Genre
                        {
                            Name = genre
                        };

                        context.Genres.Add(genreExists);
                        context.SaveChanges(); 
                    }

                    var book = new Book
                    {
                        Title = title,
                        GenreId = genreExists.Id,
                        Year = year,
                        AuthorId = AppController.currentUser.Id
                    };

                    context.Books.Add(book);
                    context.SaveChanges(); 

                    transaction.Commit();

                    Console.WriteLine("Book added successfully");

                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
