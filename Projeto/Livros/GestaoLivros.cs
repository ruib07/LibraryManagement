using Projeto.Listas;
using System;

namespace Projeto.Livros
{
    public class GestaoLivros
    {
        #region Private Properties

        private readonly ListasLivrosUsers _listas;

        #endregion

        #region Constructors

        public GestaoLivros(ListasLivrosUsers listas) => _listas = listas;

        #endregion

        #region Public Methods

        public void CriarLivro()
        {
            while (true)
            {
                LivrosData novoLivro = new();

                Console.Write("Código (0 para sair): ");
                novoLivro.Cod = Console.ReadLine();

                if (novoLivro.Cod == "0") break;

                Console.Write("Id: ");
                if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                {
                    Console.WriteLine("Id inválido!");
                    continue;
                }
                novoLivro.Id = id;

                Console.Write("Título: ");
                novoLivro.Titulo = Console.ReadLine();

                Console.Write("Autor: ");
                novoLivro.Autor = Console.ReadLine();

                Console.Write("Género: ");
                novoLivro.Genero = Console.ReadLine();

                Console.Write("ISBN: ");
                if (!int.TryParse(Console.ReadLine(), out int isbn) || isbn <= 0)
                {
                    Console.WriteLine("ISBN inválido!");
                    continue;
                }
                novoLivro.ISBN = isbn;

                Console.Write("Stock: ");
                if (!int.TryParse(Console.ReadLine(), out int stock) || stock < 0)
                {
                    Console.WriteLine("Stock inválido!");
                    continue;
                }
                novoLivro.Stock = stock;

                Console.Write("Preço: ");
                if (!float.TryParse(Console.ReadLine(), out float preco) || preco < 0)
                {
                    Console.WriteLine("Preço inválido!");
                    continue;
                }
                novoLivro.Preco = preco;

                Console.Write("Iva (6% ou 23%): ");
                if (!float.TryParse(Console.ReadLine(), out float iva) || (iva != 0.06f && iva != 0.23f))
                {
                    Console.WriteLine("Iva inválido!");
                    continue;
                }
                novoLivro.Iva = iva;

                _listas.Livros.Add(novoLivro);
                Console.WriteLine("Livro criado com sucesso!");
            }
        }

        public void AtualizarLivro()
        {
            while (true)
            {
                Console.Write("Qual é o id que deseja modificar? (0 para encerrar): ");
                if (!int.TryParse(Console.ReadLine(), out int id) || id < 0)
                {
                    Console.WriteLine("Id inválido!");
                    continue;
                }

                if (id == 0) break;

                var livro = _listas.Livros.Find(l => l.Id == id);
                if (livro == null)
                {
                    Console.WriteLine("Livro não encontrado!");
                    continue;
                }

                AtualizarInformacoesLivro(livro);
                Console.WriteLine("Livro atualizado com sucesso!");
            }
        }

        public void RemoverLivro()
        {
            Console.Write("Insira o ID do livro que deseja remover: ");
            if (!int.TryParse(Console.ReadLine(), out int idRemover))
            {
                Console.WriteLine("Id inválido!");
                return;
            }

            var livro = _listas.Livros.Find(l => l.Id == idRemover);

            if (livro != null)
            {
                _listas.Livros.Remove(livro);
                Console.WriteLine("Livro removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado com esse ID.");
            }
        }

        #endregion

        #region Private Methods

        private void AtualizarInformacoesLivro(LivrosData livro)
        {
            Console.Write("Novo Código: ");
            livro.Cod = Console.ReadLine();

            Console.Write("Novo Título: ");
            livro.Titulo = Console.ReadLine();

            Console.Write("Novo Autor: ");
            livro.Autor = Console.ReadLine();

            Console.Write("Novo Género: ");
            livro.Genero = Console.ReadLine();

            Console.Write("Novo ISBN: ");
            if (!int.TryParse(Console.ReadLine(), out int isbn) || isbn <= 0)
            {
                Console.WriteLine("ISBN inválido!");
                return;
            }
            livro.ISBN = isbn;

            Console.Write("Novo Stock: ");
            if (!int.TryParse(Console.ReadLine(), out int stock) || stock < 0)
            {
                Console.WriteLine("Stock inválido!");
                return;
            }
            livro.Stock = stock;

            Console.Write("Novo Preço: ");
            if (!float.TryParse(Console.ReadLine(), out float preco) || preco < 0)
            {
                Console.WriteLine("Preço inválido!");
                return;
            }
            livro.Preco = preco;

            Console.Write("Novo Iva (6% ou 23%): ");
            if (!float.TryParse(Console.ReadLine(), out float iva) || (iva != 0.06f && iva != 0.23f))
            {
                Console.WriteLine("Iva inválido!");
                return;
            }
            livro.Iva = iva;
        }

        #endregion
    }
}
