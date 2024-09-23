using LibraryManagementSystemEF.Data;
using LibraryManagementSystemEF.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemEF.Controllers
{
    
    internal static class MemberController
    {
        public static void Start()
        {

            while (AppController.currentUser != null)
            {
                Console.WriteLine("Welcome to the member dashboard!");
                Console.WriteLine("Please enter a number.");
                Console.WriteLine("0. View All Books");
                Console.WriteLine("1. View borrowed books");
                Console.WriteLine("2. Borrow a book");
                Console.WriteLine("3. Return a book");
                Console.WriteLine("4. Sign out");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        Console.Clear();
                        AppController.ViewBooks();
                        break;
                    case "1":
                        Console.Clear();
                        ViewBorrowedBooks();
                        break;
                    case "2":
                        Console.Clear();
                        BorrowBook();
                        break;
                    case "3":
                        Console.Clear();
                        ReturnBook();
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

        private static void ViewBorrowedBooks()
        {
            int pageNumber = 1;
            int pageSize = 5;
            bool exit = false;

            using (var context = new AppDbContext())
            {
                var totalBorrowedBooks = context.BorrowedBooks
                    .Where(bb => bb.MemberId == AppController.currentUser.Id)
                    .Count();
                var totalPages = (int)Math.Ceiling(totalBorrowedBooks / (double)pageSize);

                if(totalBorrowedBooks == 0)
                {
                    Console.WriteLine("No borrowed books");

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

                    var borrowedBooks = context.BorrowedBooks
                        .Where(bb => bb.MemberId == AppController.currentUser.Id)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize);

                    Console.WriteLine($"Page {pageNumber}/{totalPages}\n");
                    Console.WriteLine("ID   Title                          Year   Genre             Return Date");
                    Console.WriteLine("-----------------------------------------------------------------------");

                    foreach (var borrowedBook in borrowedBooks)
                    {
                        Console.WriteLine($"{borrowedBook.Id.ToString().PadRight(4)} {borrowedBook.TitleSnapshot.PadRight(30)} {borrowedBook.YearSnapshot.ToString().PadRight(6)} {borrowedBook.GenreSnapshot.PadRight(15)} {borrowedBook.ReturnDate.ToShortDateString()}");
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

        private static void BorrowBook()
        {
            using (var context = new AppDbContext())
            {

                if (AppController.currentUser == null)
                {
                    Console.WriteLine("Invalid member");
                    return;
                }

                Console.WriteLine("Please enter the id of the book you want to borrow");

                var bookId = int.Parse(Console.ReadLine());

                LibraryBook? bookToBorrow = context.LibraryBooks
                .Include(b => b.Book)
                .Include(b => b.Book.Genre)
                .FirstOrDefault(b => b.BookId == bookId);



                if (bookToBorrow == null)
                {
                    Console.WriteLine("Invalid book id");
                    return;
                }

                if(bookToBorrow.Quantity == 0)
                {
                    Console.WriteLine("Book is out of stock");
                    return;
                }



                BorrowedBook borrowedBook = new BorrowedBook
                {
                    TitleSnapshot = bookToBorrow.Book.Title,
                    YearSnapshot = bookToBorrow.Book.Year,
                    GenreSnapshot = bookToBorrow.Book.Genre.ToString(),
                    ReturnDate = DateTime.Now.AddDays(((Member)AppController.currentUser).MembershipDuration),
                    MemberId = AppController.currentUser.Id,
                    BookDetailsId = bookToBorrow.BookId,
                    IsReturned = false,
                };


                context.BorrowedBooks.Add(borrowedBook);

                ((Member)AppController.currentUser).BorrowedBooks.Add(borrowedBook);

                bookToBorrow.Quantity--;

                try
                {
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                Console.WriteLine("Book borrowed successfully");
            }
        }

        private static void ReturnBook()
        {
            using (var context = new AppDbContext())
            {
                Console.WriteLine("Please enter the id of the book you want to return");

                var bookId = int.Parse(Console.ReadLine());

                var borrowedBook = context.BorrowedBooks.FirstOrDefault(bb => bb.Id == bookId);

                if (borrowedBook == null)
                {
                    Console.WriteLine("Invalid book id");
                    return;
                }

                context.BorrowedBooks.Remove(borrowedBook);

                var bookToReturn = context.LibraryBooks.FirstOrDefault(b => b.BookId == borrowedBook.BookDetails.Id);

                bookToReturn.Quantity++;

                context.SaveChanges();

                Console.WriteLine("Book returned successfully");
            }
        }
    }
}
