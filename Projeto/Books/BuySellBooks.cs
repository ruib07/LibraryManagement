using Project.Lists;

namespace Project.Books;

public class BuySellBooks
{
    #region Private Properties

    private readonly BooksUsersLists _lists;

    #endregion

    #region Constructors

    public BuySellBooks(BooksUsersLists lists) => _lists = lists;

    #endregion

    #region Public Methods

    public void BuyBook()
    {
        while (true)
        {
            Console.Write("Enter the ID of the book you want to buy (0 to exit): ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id < 0)
            {
                Console.WriteLine("Invalid Id!");
                continue;
            }

            if (id == 0) break;

            var book = _lists.Books.Find(b => b.Id == id);

            if (book == null)
            {
                Console.WriteLine("Invalid Id!");
                continue;
            }

            Console.Write("Quantity you want to purchase: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
            {
                Console.WriteLine("Invalid Quantity!");
                continue;
            }

            if (quantity > book.Stock)
            {
                Console.WriteLine("Quantity not available!");
                continue;
            }

            book.Stock -= quantity;
            float total = quantity * book.Price;

            Console.WriteLine($"Total Amount: {Math.Round(total, 2)}");

            if (total >= 50)
            {
                float discount = total * 0.10f;
                Console.WriteLine($"10% discount: {Math.Round(discount, 2)}");
                total -= discount;
            }

            Console.WriteLine($"Total to pay: {Math.Round(total, 2)}");

            DisplayBookInformations(book);
        }
    }

    public void SellBook()
    {
        while (true)
        {
            Console.Write("Enter the ID of the book you want to sell (0 to exit): ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id < 0)
            {
                Console.WriteLine("Invalid Id!");
                continue;
            }

            if (id == 0) break;

            var book = _lists.Books.Find(b => b.Id == id);

            if (book == null)
            {
                Console.WriteLine("Invalid Id!");
                continue;
            }

            Console.Write("Quantity you want to sell: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
            {
                Console.WriteLine("Invalid Quantity!");
                continue;
            }
            book.Stock += quantity;

            DisplayBookInformations(book);
        }
    }

    #endregion

    #region Private Methods

    private void DisplayBookInformations(BooksData book)
    {
        Console.WriteLine("Code: " + book.Code + " | " + "Title: " + book.Title + " | " + "Author: " + book.Author + " | "
                                + "Genre: " + book.Genre + " | " + "ISBN: " + book.ISBN + " | " + "Stock: " + book.Stock + " | "
                                    + "Price: " + book.Price + " | " + "Iva: " + book.Iva);
    }

    #endregion
}
