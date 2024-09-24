
using LibraryManagementSystemEF.Data;
using LibraryManagementSystemEF.Entities;

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
