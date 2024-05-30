using Projeto.Listas;

namespace Projeto.Livros;

public class GestaoLivros
{
    #region Private Properties

    private ListasLivrosUsers _listas;

    #endregion

    #region Constructors

    public GestaoLivros(ListasLivrosUsers listas)
    {
        _listas = listas;
    }

    #endregion

    #region Public Methods

    public void CriarLivro()
    {
        LivrosData novolivro = new LivrosData();

        while (novolivro.Cod != "0")
        {
            Console.WriteLine("Código: ");
            novolivro.Cod = Convert.ToString(Console.ReadLine());

            if (novolivro.Cod != "0")
            {
                Console.Write("Id: ");
                novolivro.Id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Título: ");
                novolivro.Titulo = Convert.ToString(Console.ReadLine());

                Console.Write("Autor: ");
                novolivro.Autor = Convert.ToString(Console.ReadLine());

                Console.Write("Género: ");
                novolivro.Genero = Convert.ToString(Console.ReadLine());

                Console.Write("ISBN: ");
                novolivro.ISBN = (int)Convert.ToInt64(Console.ReadLine());

                Console.Write("Stock: ");
                novolivro.Stock = Convert.ToInt32(Console.ReadLine());

                Console.Write("Preço: ");
                novolivro.Preco = float.Parse(Console.ReadLine());

                Console.Write("Iva de 6% e 23%: ");
                novolivro.Iva = float.Parse(Console.ReadLine());

                Console.WriteLine("Livro criado com sucesso!");

                _listas.Livros.Add(novolivro);
            }
        }
    }

    public void AtualizarLivro()
    {
        while (true)
        {
            var id = 0;

            Console.Write("Qual é o id que deseja modificar? (0 para encerrar)");

            if (int.TryParse(Console.ReadLine(), out id))
            {
                if (id == 0) break;

                var Livro = _listas.Livros.Find(x => x.Id == id);

                if (Livro != null)
                {
                    Console.Write("Novo Código: ");
                    Livro.Cod = Convert.ToString(Console.ReadLine());

                    Console.Write("Novo Título: ");
                    Livro.Titulo = Convert.ToString(Console.ReadLine());

                    Console.Write("Novo Autor: ");
                    Livro.Autor = Convert.ToString(Console.ReadLine());

                    Console.Write("Novo Género: ");
                    Livro.Genero = Convert.ToString(Console.ReadLine());

                    Console.Write("Novo ISBN: ");
                    Livro.ISBN = (int)Convert.ToInt64(Console.ReadLine());

                    Console.Write("Novo Stock: ");
                    Livro.Stock = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Novo Preço: ");
                    Livro.Preco = float.Parse(Console.ReadLine());

                    Console.Write("Novo Iva: ");
                    Livro.Iva = float.Parse(Console.ReadLine());
                }
            }
            else
            {
                Console.WriteLine("ID inválido!");
            }

        }

        foreach (LivrosData l in _listas.Livros)
        {
            Console.WriteLine("Código: " + l.Cod + " | " + "Título: " + l.Titulo + " | " + "Autor: " + l.Autor + " | "
                                + "Género: " + l.Genero + " | " + "ISBN: " + l.ISBN + " | " + "Stock: " + l.Stock + " | " 
                                    + "Preço: " + l.Preco + " | " + "Iva: " + l.Iva);
        }
    }

    #endregion
}
