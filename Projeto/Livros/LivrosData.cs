namespace Projeto.Livros;

public class LivrosData
{
    #region Public Properties

    public int Id { get; set; }
    public string Cod { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Genero { get; set; }
    public int ISBN { get; set; }
    public int Quantidade { get; set; }
    public int Stock { get; set; }
    public float Preco { get; set; }
    public float Total { get; set; }
    public float NovoTotal { get; set; }
    public float Iva { get; set; }
    public float NovoIva { get; set; }

    #endregion

    #region Constructors

    public LivrosData() { }


    public LivrosData(int id, string cod, string titulo, string autor, string genero, int iSBN, int stock, float preco, float iva)
    {
        Id = id;
        Cod = cod;
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        ISBN = iSBN;
        Stock = stock;
        Preco = preco;
        Iva = iva;
    }

    #endregion
}
