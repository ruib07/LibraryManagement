using Project.Lists;

namespace Project.Books
{
    public class BooksManagement
    {
        #region Private Properties

        private readonly BooksUsersLists _lists;

        #endregion

        #region Constructors

        public BooksManagement(BooksUsersLists lists) => _lists = lists;

        #endregion

        #region Public Methods

        public void CreateBook()
        {
            while (true)
            {
                BooksData newBook = new();

                Console.Write("Code (0 to close): ");
                newBook.Code = Console.ReadLine();

                if (newBook.Code == "0") break;

                Console.Write("Id: ");
                if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                {
                    Console.WriteLine("Invalid Id!");
                    continue;
                }
                newBook.Id = id;

                Console.Write("Title: ");
                newBook.Title = Console.ReadLine();

                Console.Write("Author: ");
                newBook.Author = Console.ReadLine();

                Console.Write("Genre: ");
                newBook.Genre = Console.ReadLine();

                Console.Write("ISBN: ");
                if (!int.TryParse(Console.ReadLine(), out int isbn) || isbn <= 0)
                {
                    Console.WriteLine("Invalid ISBN!");
                    continue;
                }
                newBook.ISBN = isbn;

                Console.Write("Stock: ");
                if (!int.TryParse(Console.ReadLine(), out int stock) || stock < 0)
                {
                    Console.WriteLine("Invalid Stock!");
                    continue;
                }
                newBook.Stock = stock;

                Console.Write("Price: ");
                if (!float.TryParse(Console.ReadLine(), out float price) || price < 0)
                {
                    Console.WriteLine("Invalid Price!");
                    continue;
                }
                newBook.Price = price;

                Console.Write("Iva (6% or 23%): ");
                if (!float.TryParse(Console.ReadLine(), out float iva) || (iva != 0.06f && iva != 0.23f))
                {
                    Console.WriteLine("Invalid Iva!");
                    continue;
                }
                newBook.Iva = iva;

                _lists.Books.Add(newBook);

                Console.WriteLine("Book created successfully!");
            }
        }

        public void UpdateBook()
        {
            while (true)
            {
                Console.Write("What is the id you want to modify? (0 to close): ");
                if (!int.TryParse(Console.ReadLine(), out int id) || id < 0)
                {
                    Console.WriteLine("Invalid Id!");
                    continue;
                }

                if (id == 0) break;

                var book = _lists.Books.Find(l => l.Id == id);

                if (book == null)
                {
                    Console.WriteLine("Book not found!");
                    continue;
                }

                UpdateBookInformations(book);

                Console.WriteLine("Book updated successfully!");
            }
        }

        public void RemoveBook()
        {
            Console.Write("Enter the ID of the book you want to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int idRemove))
            {
                Console.WriteLine("Invalid Id!");
                return;
            }

            var book = _lists.Books.Find(l => l.Id == idRemove);

            if (book != null)
            {
                _lists.Books.Remove(book);
                Console.WriteLine("Book removed successfully!");
            }
            else Console.WriteLine("Book not found with that id.");
        }

        #endregion

        #region Private Methods

        private void UpdateBookInformations(BooksData book)
        {
            Console.Write("New Code: ");
            book.Code = Console.ReadLine();

            Console.Write("New Title: ");
            book.Title = Console.ReadLine();

            Console.Write("New Author: ");
            book.Author = Console.ReadLine();

            Console.Write("New Genre: ");
            book.Genre = Console.ReadLine();

            Console.Write("New ISBN: ");
            if (!int.TryParse(Console.ReadLine(), out int isbn) || isbn <= 0)
            {
                Console.WriteLine("Invalid ISBN!");
                return;
            }
            book.ISBN = isbn;

            Console.Write("New Stock: ");
            if (!int.TryParse(Console.ReadLine(), out int stock) || stock < 0)
            {
                Console.WriteLine("Invalid Stock!");
                return;
            }
            book.Stock = stock;

            Console.Write("New Price: ");
            if (!float.TryParse(Console.ReadLine(), out float price) || price < 0)
            {
                Console.WriteLine("Invalid Preço!");
                return;
            }
            book.Price = price;

            Console.Write("New Iva (6% or 23%): ");
            if (!float.TryParse(Console.ReadLine(), out float iva) || (iva != 0.06f && iva != 0.23f))
            {
                Console.WriteLine("Invalid Iva!");
                return;
            }
            book.Iva = iva;
        }

        #endregion
    }
}
