using Projeto.Listas;
using Projeto.Livros;
using Projeto.Utilizadores;

namespace Projeto.Consultar
{
    public class Consultas
    {
        #region Private Properties

        private readonly ListasLivrosUsers _listas;

        #endregion

        #region Constructor

        public Consultas(ListasLivrosUsers listas) => _listas = listas;

        #endregion

        #region Public Methods

        public void ConsultarUtilizadores()
        {
            foreach (var u in _listas.Utilizadores)
            {
                Console.WriteLine($"Id: {u.IdUser} | Admin: {u.Admin} | Password: {u.Password}");
            }
        }

        public void ConsultarLivros()
        {
            foreach (var l in _listas.Livros)
            {
                ExibirDetalhesLivro(l);
            }
        }

        public void ConsultarLivrosGenero() => ConsultarLivroPorParametro("género", l => l.Genero);

        public void ConsultarLivroAutor() => ConsultarLivroPorParametro("autor", l => l.Autor);

        public void ConsultarStock()
        {
            while (true)
            {
                int id = ObterEntradaInt("Qual é o id do livro que deseja consultar o stock? (0 para encerrar)");

                if (id == 0) break;

                var livro = _listas.Livros.Find(x => x.Id == id);
                if (livro != null)
                {
                    Console.WriteLine($"Título: {livro.Titulo} | Stock: {livro.Stock}");
                }
                else
                {
                    Console.WriteLine("Id inválido. Tente novamente!");
                }
            }
        }

        public void ConsultarLivrosCod() => ConsultarLivroPorParametro("código", l => l.Cod);

        public void ConsultarLivrosTitulo() => ConsultarLivroPorParametro("título", l => l.Titulo);

        public void ConsultarTotalVendidoEReceita()
        {
            while (true)
            {
                int id = ObterEntradaInt("Insira o id que deseja consultar o total vendido e a sua receita: (0 para encerrar)");

                if (id == 0) break;

                var livro = _listas.Livros.Find(x => x.Id == id);
                if (livro != null)
                {
                    int totalLivrosVendidos = livro.Quantidade;
                    float totalReceita = livro.Total >= 50 ? livro.NovoTotal : livro.Total;

                    Console.WriteLine($"Total de livros vendidos: {totalLivrosVendidos}");
                    Console.WriteLine($"Total de receita: {totalReceita:F2}");
                }
                else
                {
                    Console.WriteLine("Id inválido. Tente novamente!");
                }
            }
        }

        #endregion

        #region Private Methods

        private void ConsultarLivroPorParametro(string parametro, Func<LivrosData, string> seletor)
        {
            while (true)
            {
                Console.Write($"Insira o {parametro} do livro que deseja consultar: (Sair para encerrar)");
                string entrada = Console.ReadLine();

                if (entrada.Equals("Sair", StringComparison.OrdinalIgnoreCase)) break;

                var livro = _listas.Livros.Find(l => seletor(l).Equals(entrada, StringComparison.OrdinalIgnoreCase));
                if (livro != null)
                {
                    ExibirDetalhesLivro(livro);
                }
                else
                {
                    Console.WriteLine($"{parametro.Capitalize()} inválido. Tente novamente!");
                }
            }
        }

        private static int ObterEntradaInt(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                if (int.TryParse(Console.ReadLine(), out int resultado))
                {
                    return resultado;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro.");
                }
            }
        }

        private static void ExibirDetalhesLivro(LivrosData livro)
        {
            Console.WriteLine($"Código: {livro.Cod} | Título: {livro.Titulo} | Autor: {livro.Autor} | " +
                                $"Género: {livro.Genero} | ISBN: {livro.ISBN} | Stock: {livro.Stock} | " +
                                    $"Preço: {livro.Preco} | Iva: {livro.Iva}");
        }

        #endregion
    }

    public static class StringExtensions
    {
        public static string Capitalize(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
