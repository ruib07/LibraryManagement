using Project.Books;
using Project.Users;

namespace Project.Lists;

public class BooksUsersLists
{
    #region Public Properties

    public List<UsersData> Users { get; private set; }
    public List<BooksData> Books { get; private set; }

    #endregion

    #region Constructor

    public BooksUsersLists()
    {
        Users = new List<UsersData>()
        {
            new UsersData(1, "Manager", "manager123"),
            new UsersData(2, "Stocker", "stocker123"),
            new UsersData(3, "Cashier", "cashier123")
        };

        Books = new List<BooksData>()
        {
            new BooksData(1, "A44S", "Com o Humor Não se Brinca", "Nelson Nunes", "Comédia", 123456789, 22, (float)19.99, (float)0.23),
            new BooksData(2, "A55", "O Exorcista", "William Peter Blatty", "Terror", 987654321, 25, (float)9.99, (float)0.23),
            new BooksData(3, "B32", "Moby Dick", "Herman Melville", "Ação", 123454321, 20, (float)4.99, (float)0.06)
        };
    }

    #endregion
}
