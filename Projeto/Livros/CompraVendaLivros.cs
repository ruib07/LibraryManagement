using Projeto.Listas;

namespace Projeto.Livros;

public class CompraVendaLivros
{
    #region Private Properties

    private ListasLivrosUsers _listas;

    #endregion

    #region Constructors

    public CompraVendaLivros(ListasLivrosUsers listas)
    {
        _listas = listas;
    }

    #endregion

    #region Public Methods

    public void ComprarLivro()
    {
        while (true)
        {
            Console.Write("Insira o Id do livro que deseja comprar (0 para sair): ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (id == 0) break;

            var livro = _listas.Livros.Find(l => l.Id == id);

            if (livro == null)
            {
                Console.WriteLine("Id inválido!");

                continue;
            }

            Console.Write("Quantidade que deseja comprar: ");
            livro.Quantidade = Convert.ToInt32(Console.ReadLine());

            if (livro.Quantidade >= 0 && livro.Quantidade <= livro.Stock)
            {
                livro.Stock -= livro.Quantidade;

                livro.Total = livro.Quantidade * livro.Preco;

                Console.WriteLine($"Valor total: {Math.Round(livro.Total, 2)}");

                if (livro.Total >= 50)
                {
                    livro.NovoIva = (float)(livro.Total * 0.10);
                    Console.WriteLine($"Desconto de 10%: {Math.Round(livro.NovoIva, 2)}");

                    livro.NovoTotal = (float)(livro.Total - livro.NovoIva);
                    Console.WriteLine($"Total a pagar: {Math.Round(livro.NovoTotal, 2)}");
                }

                Console.WriteLine("Código: " + livro.Cod + " | " + "Título: " + livro.Titulo + " | " + "Autor: " + livro.Autor + " | "
                                    + "Género: " + livro.Genero + " | " + "ISBN: " + livro.ISBN + " | " + "Stock: " + livro.Stock + " | " 
                                        + "Preço: " + livro.Preco + " | " + "Iva: " + livro.Iva);
            }
            else
            {
                Console.WriteLine("Quantidade não disponível!");
            }
        }
    }

    public void VenderLivro()
    {
        while (true)
        {
            Console.Write("Insira o Id do livro que deseja vender (0 para sair): ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (id == 0) break;

            var livro = _listas.Livros.Find(l => l.Id == id);

            if (livro == null)
            {
                Console.WriteLine("Id inválido!");

                continue;
            }

            Console.Write("Quantidade que deseja vender: ");
            livro.Quantidade = Convert.ToInt32(Console.ReadLine());

            livro.Stock += livro.Quantidade;

            Console.WriteLine("Código: " + livro.Cod + " | " + "Título: " + livro.Titulo + " | " + "Autor: " + livro.Autor + " | "
                                + "Género: " + livro.Genero + " | " + "ISBN: " + livro.ISBN + " | " + "Stock: " + livro.Stock + " | " 
                                    + "Preço: " + livro.Preco + " | " + "Iva: " + livro.Iva);
        }
    }

    #endregion
}
