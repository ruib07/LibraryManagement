using Projeto.Listas;

namespace Projeto.Livros;

public class CompraVendaLivros
{
    #region Private Properties

    private readonly ListasLivrosUsers _listas;

    #endregion

    #region Constructors

    public CompraVendaLivros(ListasLivrosUsers listas) => _listas = listas;

    #endregion

    #region Public Methods

    public void ComprarLivro()
    {
        while (true)
        {
            Console.Write("Insira o Id do livro que deseja comprar (0 para sair): ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id < 0)
            {
                Console.WriteLine("Id inválido!");
                continue;
            }

            if (id == 0) break;

            var livro = _listas.Livros.Find(l => l.Id == id);
            if (livro == null)
            {
                Console.WriteLine("Id inválido!");
                continue;
            }

            Console.Write("Quantidade que deseja comprar: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade < 0)
            {
                Console.WriteLine("Quantidade inválida!");
                continue;
            }

            if (quantidade > livro.Stock)
            {
                Console.WriteLine("Quantidade não disponível!");
                continue;
            }

            livro.Stock -= quantidade;
            float total = quantidade * livro.Preco;
            Console.WriteLine($"Valor total: {Math.Round(total, 2)}");

            if (total >= 50)
            {
                float desconto = total * 0.10f;
                Console.WriteLine($"Desconto de 10%: {Math.Round(desconto, 2)}");
                total -= desconto;
            }

            Console.WriteLine($"Total a pagar: {Math.Round(total, 2)}");
            ExibirInformacoesLivro(livro);
        }
    }

    public void VenderLivro()
    {
        while (true)
        {
            Console.Write("Insira o Id do livro que deseja vender (0 para sair): ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id < 0)
            {
                Console.WriteLine("Id inválido!");
                continue;
            }

            if (id == 0) break;

            var livro = _listas.Livros.Find(l => l.Id == id);

            if (livro == null)
            {
                Console.WriteLine("Id inválido!");
                continue;
            }

            Console.Write("Quantidade que deseja vender: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade < 0)
            {
                Console.WriteLine("Quantidade inválida!");
                continue;
            }

            livro.Stock += quantidade;
            ExibirInformacoesLivro(livro);
        }
    }

    #endregion

    #region Private Methods

    private void ExibirInformacoesLivro(LivrosData livro)
    {
        Console.WriteLine("Código: " + livro.Cod + " | " + "Título: " + livro.Titulo + " | " + "Autor: " + livro.Autor + " | "
                                + "Género: " + livro.Genero + " | " + "ISBN: " + livro.ISBN + " | " + "Stock: " + livro.Stock + " | "
                                    + "Preço: " + livro.Preco + " | " + "Iva: " + livro.Iva);
    }

    #endregion
}
