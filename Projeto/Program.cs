using Project.Consult;
using Project.Books;
using Project.Presentation;
using Project.Users;
using Project.Lists;

#region Data

UsersData ud = new UsersData();
BooksData bd = new BooksData();

#endregion

#region Lists

BooksUsersLists bul = new BooksUsersLists();

#endregion

#region Management

UsersManagement um = new UsersManagement(bul);
BooksManagement bm = new BooksManagement(bul);

#endregion

#region Buy/Sell or Consult

BuySellBooks bsb = new BuySellBooks(bul);
Queries q = new Queries(bul);

#endregion

#region UI

Interface i = new Interface(ud, q, um, bm, bsb);
i.ShowOptions();

#endregion

Console.ReadKey();