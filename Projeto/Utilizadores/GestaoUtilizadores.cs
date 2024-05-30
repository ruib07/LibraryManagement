using Projeto.Listas;
using System;

namespace Projeto.Utilizadores
{
    public class GestaoUtilizadores
    {
        #region Public Properties

        public string Opcao { get; set; }

        #endregion

        #region Private Properties

        private readonly ListasLivrosUsers _listas;

        #endregion

        #region Constructor

        public GestaoUtilizadores(ListasLivrosUsers listas) => _listas = listas;

        #endregion

        #region Public Methods

        public void CriarRemoverUtilizador()
        {
            while (true)
            {
                Console.WriteLine("Escolha uma opção (Criar, Remover, Sair): ");
                Opcao = Console.ReadLine();

                switch (Opcao)
                {
                    case "Criar":
                        CriarUtilizador();
                        break;

                    case "Remover":
                        RemoverUtilizador();
                        break;

                    case "Sair":
                        return;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        #endregion

        #region Private Methods

        private void CriarUtilizador()
        {
            UtilizadoresData novoUtilizador = new();

            Console.Write("Novo Id (0 para cancelar): ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("Id inválido!");
                return;
            }
            novoUtilizador.IdUser = id;

            Console.Write("Novo Admin: ");
            novoUtilizador.Admin = Console.ReadLine();

            Console.Write("Nova Password: ");
            novoUtilizador.Password = Console.ReadLine();

            _listas.Utilizadores.Add(novoUtilizador);
            Console.WriteLine("Utilizador criado com sucesso!");
            Console.WriteLine($"Admin: {novoUtilizador.Admin} | Password: {novoUtilizador.Password}");
        }

        private void RemoverUtilizador()
        {
            Console.Write("Insira o ID do utilizador que deseja remover: ");
            if (!int.TryParse(Console.ReadLine(), out int idRemover))
            {
                Console.WriteLine("Id inválido!");
                return;
            }

            var utilizador = _listas.Utilizadores.Find(u => u.IdUser == idRemover);
            if (utilizador != null)
            {
                _listas.Utilizadores.Remove(utilizador);
                Console.WriteLine("Utilizador removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Utilizador não encontrado com esse ID.");
            }
        }

        #endregion
    }
}
