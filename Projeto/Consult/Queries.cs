using Project.Lists;
using Project.Books;

namespace Project.Consult
{
    public class Queries
    {
        #region Private Properties

        private readonly BooksUsersLists _lists;

        #endregion

        #region Constructor

        public Queries(BooksUsersLists lists) => _lists = lists;

        #endregion

        #region Public Methods

        public void ConsultUsers()
        {
            foreach (var u in _lists.Users)
            {
                Console.WriteLine($"Id: {u.UserId} | Admin: {u.Admin} | Password: {u.Password}");
            }
        }

        public void ConsultBooks()
        {
            foreach (var b in _lists.Books)
            {
                DisplayBookDetails(b);
            }
        }

        public void ConsultBookByGenre() => ConsultBookByParameter("genre", l => l.Genre);

        public void ConsultBookByAuthor() => ConsultBookByParameter("author", l => l.Author);

        public void ConsultBookStock()
        {
            while (true)
            {
                int id = GetEntryInt("What is the ID of the book you want to check the stock? (0 to close)");

                if (id == 0) break;

                var book = _lists.Books.Find(x => x.Id == id);

                if (book != null) Console.WriteLine($"Title: {book.Title} | Stock: {book.Stock}");

                else Console.WriteLine("Invalid id. Try again!");
            }
        }

        public void ConsultBookByCode() => ConsultBookByParameter("code", l => l.Code);

        public void ConsultBookByTitle() => ConsultBookByParameter("title", l => l.Title);

        public void ConsultRevenueAndTotalBooksSold()
        {
            while (true)
            {
                int id = GetEntryInt("Enter the ID you want to check the total sold and your revenue: (0 to close)");

                if (id == 0) break;

                var book = _lists.Books.Find(x => x.Id == id);

                if (book != null)
                {
                    int totalBooksSold = book.Amount;
                    float totalRevenue = book.Total >= 50 ? book.NewTotal : book.Total;

                    Console.WriteLine($"Total books sold: {totalBooksSold}");
                    Console.WriteLine($"Total revenue: {totalRevenue:F2}");
                }
                else Console.WriteLine("Invalid Id. Try again!");
            }
        }

        #endregion

        #region Private Methods

        private void ConsultBookByParameter(string parameter, Func<BooksData, string> selector)
        {
            while (true)
            {
                Console.Write($"Enter the {parameter} of the book you want to consult: (Exit to close)");
                string input = Console.ReadLine();

                if (input.Equals("Exit", StringComparison.OrdinalIgnoreCase)) break;

                var book = _lists.Books.Find(b => selector(b).Equals(input, StringComparison.OrdinalIgnoreCase));

                if (book != null) DisplayBookDetails(book);

                else Console.WriteLine($"Invalid {parameter.Capitalize()}. Try again!");
            }
        }

        private static int GetEntryInt(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out int result)) return result;

                else Console.WriteLine("Invalid Input. Please enter an integer.");
            }
        }

        private static void DisplayBookDetails(BooksData livro)
        {
            Console.WriteLine($"Code: {livro.Code} | Title: {livro.Title} | Author: {livro.Author} | " +
                                $"Genre: {livro.Genre} | ISBN: {livro.ISBN} | Stock: {livro.Stock} | " +
                                    $"Price: {livro.Price} | Iva: {livro.Iva}");
        }

        #endregion
    }

    public static class StringExtensions
    {
        public static string Capitalize(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
