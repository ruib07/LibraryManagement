using Project.Consult;
using Project.Books;
using Project.Users;

namespace Project.Presentation;

public class Interface
{
    #region Private Properties

    private readonly UsersData _users;
    private readonly Queries _queries;
    private readonly UsersManagement _usersManagement;
    private readonly BooksManagement _booksManagement;
    private readonly BuySellBooks _buySellBooks;

    #endregion

    #region Constructor

    public Interface(UsersData users, Queries queries, UsersManagement usersManagement, BooksManagement booksManagement, BuySellBooks buySellBooks)
    {
        _users = users;
        _queries = queries;
        _usersManagement = usersManagement;
        _booksManagement = booksManagement;
        _buySellBooks = buySellBooks;
    }

    #endregion

    #region Public Methods

    public void Menu()
    {
        Console.WriteLine("----------------CHOOSE A OPTION-------------------\n\n");
        Console.WriteLine("1- Create/Remove Users");
        Console.WriteLine("2- Create Book");
        Console.WriteLine("3- Update Book");
        Console.WriteLine("4- Remove Book");
        Console.WriteLine("5- Consult Users");
        Console.WriteLine("6- Consult Books");
        Console.WriteLine("7- Buy Book");
        Console.WriteLine("8- Sell Book");
        Console.WriteLine("9- Consult Book by Genre");
        Console.WriteLine("10- Consult Book by Author");
        Console.WriteLine("11- Consult Book by Stock");
        Console.WriteLine("12- Consult Book by Code");
        Console.WriteLine("13- Consult Book by Title");
        Console.WriteLine("14- Consult Total Books Sold and Revenue");
        Console.WriteLine("15- Mudar de Utilizador");
        Console.WriteLine("16- Exit\n\n");
        Console.WriteLine("----------------------------------------------------");
    }

    public void InitializeInterface() => ShowOptions();

    public void ShowOptions()
    {
        AuthenticateUser();
        var options = CreateOptionsMap();

        int option;

        do
        {
            try
            {
                Menu();
                Console.Write("\n\nChoose a option: ");
                option = Convert.ToInt32(Console.ReadLine());

                if (options.TryGetValue(option, out var action)) action.Invoke();

                else Console.WriteLine("Invalid option, try again.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please insert only numbers!");
                option = 0;
            }
        } while (option != 16);

        Console.Clear();
        Console.WriteLine("Have a good day!");
    }

    #endregion

    #region Private Methods

    private Dictionary<int, Action> CreateOptionsMap()
    {
        return new Dictionary<int, Action>
        {
            { 1, () => CheckPermission("Manager", Option1) },
            { 2, () => CheckPermission("Stocker", Option2) },
            { 3, _booksManagement.UpdateBook },
            { 4, () => CheckPermission("Stocker", Option4) },
            { 5, _queries.ConsultUsers },
            { 6, _queries.ConsultBooks },
            { 7, () => CheckPermission(new[] { "Cashier", "Manager"}, Option6) },
            { 8, _buySellBooks.SellBook },
            { 9, _queries.ConsultBookByGenre },
            { 10, _queries.ConsultBookByAuthor },
            { 11, _queries.ConsultBookStock },
            { 12, _queries.ConsultBookByCode },
            { 13, _queries.ConsultBookByTitle },
            { 14, _queries.ConsultRevenueAndTotalBooksSold },
            { 15, InitializeInterface },
            { 16, () => { } }
        };
    }

    private void AuthenticateUser()
    {
        do
        {
            Console.WriteLine("------------------------LOGIN--------------------------\n\n");

            Console.Write("Admin: ");
            _users.Admin = Console.ReadLine();

            Console.Write("Password: ");
            _users.Password = ReadPassword();

            if (!ValidateCredentials(_users.Admin, _users.Password))
                    Console.WriteLine("Invalid Admin/Password. Try again.");

        } while (!ValidateCredentials(_users.Admin, _users.Password));
    }

    private bool ValidateCredentials(string admin, string password)
    {
        return (admin, password) switch
        {
            ("Manager", "manager123") => true,
            ("Stocker", "stocker123") => true,
            ("Cashier", "cashier123") => true,
            _ => false
        };
    }

    private void CheckPermission(string role, Action action)
    {
        if (_users.Admin == role) action.Invoke();

        else Console.WriteLine("Access denied!");
    }

    private void CheckPermission(string[] roles, Action action)
    {
        if (roles.Contains(_users.Admin)) action.Invoke();

        else Console.WriteLine("Access denied!");
    }

    private void Option1() => _usersManagement.CreateRemoveUser();

    private void Option2() => _booksManagement.CreateBook();
    private void Option4() => _booksManagement.RemoveBook();

    private void Option6() => _buySellBooks.BuyBook();

    private string ReadPassword()
    {
        var password = string.Empty;
        ConsoleKey key;

        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && password.Length > 0)
            {
                Console.Write("\b \b");
                password = password[0..^1];
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                password += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }

    #endregion
}
