namespace Project.Books;

public class BooksData
{
    #region Public Properties

    public int Id { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int ISBN { get; set; }
    public int Amount { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
    public float Total { get; set; }
    public float NewTotal { get; set; }
    public float Iva { get; set; }

    #endregion

    #region Constructors

    public BooksData() { }


    public BooksData(int id, string code, string title, string author, string genre, int iSBN, int stock, float price, float iva)
    {
        Id = id;
        Code = code;
        Title = title;
        Author = author;
        Genre = genre;
        ISBN = iSBN;
        Stock = stock;
        Price = price;
        Iva = iva;
    }

    #endregion
}
