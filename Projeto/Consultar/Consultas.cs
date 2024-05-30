using Projeto.Listas;
using Projeto.Livros;
using Projeto.Utilizadores;

namespace Projeto.Consultar;

public class Consultas
{
    #region Private Properties

    private ListasLivrosUsers _listas;

    #endregion

    #region Constructor

    public Consultas(ListasLivrosUsers listas)
    {
        _listas = listas;
    }

    #endregion

    #region Public Methods

    public void ConsultarUtilizadores()
    {
        foreach (UtilizadoresData u in _listas.Utilizadores)
        {
            Console.WriteLine($"Id: " + u.IdUser + "| " + "Admin: " + u.Admin + " | " + "Password: " + u.Password);
        }
    }

    public void ConsultarLivros()
    {
        foreach (LivrosData l in _listas.Livros)
        {
            Console.WriteLine("Código: " + l.Cod + " | " + "Título: " + l.Titulo + " | " + "Autor: " + l.Autor + " | "
                                + "Género: " + l.Genero + " | " + "ISBN: " + l.ISBN + " | " + "Stock: " + l.Stock + " | " 
                                    + "Preço: " + l.Preco + " | " + "Iva: " + l.Iva);
        }
    }

    public void ConsultarLivrosGenero()
    {
        while (true)
        {
            var genero = "";

            Console.Write("Insira o género que deseja consultar: (Sair para encerrar)");
            genero = Convert.ToString(Console.ReadLine());

            if (genero == "Sair") break;

            var Livro = _listas.Livros.Find(x => x.Genero == genero);

            if (Livro != null)
            {
                Console.WriteLine("Código: " + Livro.Cod + " | " + "Título: " + Livro.Titulo + " | " + "Autor: " + Livro.Autor + " | "
                                    + "Género: " + Livro.Genero + " | " + "ISBN: " + Livro.ISBN + " | " + "Stock: " + Livro.Stock + " | " 
                                        + "Preço: " + Livro.Preco + " | " + "Iva: " + Livro.Iva);
            }
            else
            {
                Console.WriteLine("Género inválido. Tente novamente!");
            }
        }
    }

    public void ConsultarLivroAutor()
    {
        while (true)
        {
            var autor = "";

            Console.Write("Insira o autor que deseja consultar: (Sair para encerrar)");
            autor = Convert.ToString(Console.ReadLine());

            if (autor == "Sair") break;

            var Livro = _listas.Livros.Find(x => x.Autor == autor);

            if (Livro != null)
            {
                Console.WriteLine("Código: " + Livro.Cod + " | " + "Título: " + Livro.Titulo + " | " + "Autor: " + Livro.Autor + " | "
                                    + "Género: " + Livro.Genero + " | " + "ISBN: " + Livro.ISBN + " | " + "Stock: " + Livro.Stock + " | " 
                                        + "Preço: " + Livro.Preco + " | " + "Iva: " + Livro.Iva);
            }
            else
            {
                Console.WriteLine("Autor inválido. Tente novamente!");
            }
        }

    }

    public void ConsultarStock()
    {
        while (true)
        {
            var id = 0;

            Console.Write("Qual é o id do livro que deseja consultar o stock? (0 para encerrar)");
            id = Convert.ToInt32(Console.ReadLine());

            if (id == 0) break;

            var Livro = _listas.Livros.Find(x => x.Id == id);

            if (Livro != null)
            {
                Console.WriteLine("Título: " + Livro.Titulo + " | " + "Stock: " + Livro.Stock);
            }
            else
            {
                Console.WriteLine("Id inválido. Tente novamente!");
            }
        }
    }

    public void ConsultarLivrosCod()
    {
        while (true)
        {
            var cod = "";

            Console.Write("Insira o código do livro que deseja consultar: (Sair para encerrar)");
            cod = Convert.ToString(Console.ReadLine());

            if (cod == "Sair") break;

            var Livro = _listas.Livros.Find(x => x.Cod == cod);

            if (Livro != null)
            {
                Console.WriteLine("Código: " + Livro.Cod + " | " + "Título: " + Livro.Titulo + " | " + "Autor: " + Livro.Autor + " | "
                                    + "Género: " + Livro.Genero + " | " + "ISBN: " + Livro.ISBN + " | " + "Stock: " + Livro.Stock + " | " 
                                        + "Preço: " + Livro.Preco + " | " + "Iva: " + Livro.Iva);
            }
            else
            {
                Console.WriteLine("Código inválido. Tente novamente!");
            }
        }
    }

    public void ConsultarLivrosTitulo()
    {
        while (true)
        {
            var titulo = "";

            Console.Write("Insira o título do livro que deseja consultar: (Sair para encerrar)");
            titulo = Convert.ToString(Console.ReadLine());

            if (titulo == "Sair") break;

            var Livro = _listas.Livros.Find(x => x.Titulo == titulo);

            if (Livro != null)
            {
                Console.WriteLine("Código: " + Livro.Cod + " | " + "Título: " + Livro.Titulo + " | " + "Autor: " + Livro.Autor + " | "
                                    + "Género: " + Livro.Genero + " | " + "ISBN: " + Livro.ISBN + " | " + "Stock: " + Livro.Stock + " | " 
                                        + "Preço: " + Livro.Preco + " | " + "Iva: " + Livro.Iva);
            }
            else
            {
                Console.WriteLine("Título inválido. Tente novamente!");
            }
        }
    }

    public void ConsultarTotalVendidoEReceita()
    {
        while (true)
        {
            int id = 0;

            Console.Write("Insira o id que deseja consultar o total vendido e a sua receita: (0 para encerrar)");
            id = Convert.ToInt32(Console.ReadLine());

            if (id == 0) break;

            var Livro = _listas.Livros.Find(x => x.Id == id);

            if (Livro != null)
            {
                int totalLivrosVendidos = 0;

                totalLivrosVendidos += Livro.Quantidade;

                float TotalReceita = (float)Math.Round(Livro.Total, 2);

                if (Livro.Total >= 50)
                {
                    TotalReceita = (float)Math.Round(Livro.NovoTotal, 2);
                }

                Console.WriteLine("Total de livros vendidos: " + totalLivrosVendidos);
                Console.WriteLine("Total de receita: " + TotalReceita);
            }
            else
            {
                Console.WriteLine("Id inválido. Tente novamente!");
            }
        }
    }

    #endregion
}
