using Projeto.Listas;

namespace Projeto.Utilizadores;

public class GestaoUtilizadores
{
    #region Public Properties

    public string Opcao { get; set; }

    #endregion

    #region Private Properties

    private ListasLivrosUsers _listas;

    #endregion

    #region Constructor

    public GestaoUtilizadores(ListasLivrosUsers listas)
    {
        _listas = listas;
    }

    #endregion

    #region Public Methods

    public void CriarRemoverUtilizador()
    {
        Console.WriteLine("Escolha uma opção (Criar ou Remover e Sair para encerrar): ");
        Opcao = Convert.ToString(Console.ReadLine());

        while (true)
        {
            if (Opcao == "Criar")
            {
                UtilizadoresData novoutilizador = new UtilizadoresData();

                Console.Write("Novo Id: ");
                novoutilizador.IdUser = Convert.ToInt32(Console.ReadLine());

                if (novoutilizador.IdUser == 0) return;

                Console.Write("Novo Admin: ");
                novoutilizador.Admin = Convert.ToString(Console.ReadLine());

                Console.Write("Nova Password: ");
                novoutilizador.Password = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Utilizador criado com sucesso!");

                Console.WriteLine("Admin: " + novoutilizador.Admin + " | " + "Password: " + novoutilizador.Password);

                _listas.Utilizadores.Add(novoutilizador);
            }
            else if (Opcao == "Remover")
            {
                Console.WriteLine("Insira o ID do utilizador que deseja remover: ");
                int idRemover = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < _listas.Utilizadores.Count; i++)
                {
                    if (_listas.Utilizadores[i].IdUser == idRemover)
                    {
                        _listas.Utilizadores.RemoveAt(i);

                        Console.WriteLine("Utilizador removido com sucesso!");
                        return;
                    }
                }

                Console.WriteLine("Utilizador não encontrado com esse ID.");
            }
            else if (Opcao == "Sair") break;
        }
    }

    #endregion
}
