using Projeto.Consultar;
using Projeto.Livros;
using Projeto.Utilizadores;

namespace Projeto.Apresentacao;

public class Interface
{
    #region Private Properties

    private readonly UtilizadoresData _utilizadores;
    private readonly Consultas _consultas;
    private readonly GestaoUtilizadores _gestaoUtilizadores;
    private readonly GestaoLivros _gestaoLivros;
    private readonly CompraVendaLivros _compraVendaLivros;

    #endregion

    #region Constructor

    public Interface(UtilizadoresData utilizadores, Consultas consultas, GestaoUtilizadores gestaoUtilizadores, GestaoLivros gestaoLivros, CompraVendaLivros compraVendaLivros)
    {
        _utilizadores = utilizadores;
        _consultas = consultas;
        _gestaoUtilizadores = gestaoUtilizadores;
        _gestaoLivros = gestaoLivros;
        _compraVendaLivros = compraVendaLivros;
    }

    #endregion

    #region Public Methods

    public void Menu()
    {
        Console.WriteLine("----------------ESCOLHA UMA OPÇÃO-------------------\n\n");
        Console.WriteLine("1- Criar ou Remover Utilizadores");
        Console.WriteLine("2- Criar Livro");
        Console.WriteLine("3- Atualizar Livro");
        Console.WriteLine("4- Remover Livro");
        Console.WriteLine("5- Consultar Utilizadores");
        Console.WriteLine("6- Consultar Livros");
        Console.WriteLine("7- Comprar Livro");
        Console.WriteLine("8- Vender Livro");
        Console.WriteLine("9- Consultar Livro por Género");
        Console.WriteLine("10- Consultar Livro por Autor");
        Console.WriteLine("11- Consultar Livro por Stock");
        Console.WriteLine("12- Consultar Livro por Código");
        Console.WriteLine("13- Consultar Livro por Título");
        Console.WriteLine("14- Consultar Total Livros Vendidos e Receita");
        Console.WriteLine("15- Mudar de Utilizador");
        Console.WriteLine("16- Sair\n\n");
        Console.WriteLine("----------------------------------------------------");
    }

    public void IniciarInterface() => MostrarOpcoes();

    public void MostrarOpcoes()
    {
        AutenticarUtilizador();
        var opcoes = CriarMapaOpcoes();

        int opcao;

        do
        {
            try
            {
                Menu();
                Console.Write("\n\nEscolha uma opção: ");
                opcao = Convert.ToInt32(Console.ReadLine());

                if (opcoes.TryGetValue(opcao, out var acao))
                {
                    acao.Invoke();
                }
                else
                {
                    Console.WriteLine("Opção inválida, tente novamente.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor insira apenas números!");
                opcao = 0;
            }
        } while (opcao != 16);

        Console.Clear();
        Console.WriteLine("Tenha um bom dia!");
    }

    #endregion

    #region Private Methods

    private Dictionary<int, Action> CriarMapaOpcoes()
    {
        return new Dictionary<int, Action>
        {
            { 1, () => VerificarPermissao("Gerente", Opcao1) },
            { 2, () => VerificarPermissao("Repositor", Opcao2) },
            { 3, _gestaoLivros.AtualizarLivro },
            { 4, () => VerificarPermissao("Repositor", Opcao4) },
            { 5, _consultas.ConsultarUtilizadores },
            { 6, _consultas.ConsultarLivros },
            { 7, () => VerificarPermissao(new[] {"Caixa", "Gerente"}, Opcao6) },
            { 8, _compraVendaLivros.VenderLivro },
            { 9, _consultas.ConsultarLivrosGenero },
            { 10, _consultas.ConsultarLivroAutor },
            { 11, _consultas.ConsultarStock },
            { 12, _consultas.ConsultarLivrosCod },
            { 13, _consultas.ConsultarLivrosTitulo },
            { 14, _consultas.ConsultarTotalVendidoEReceita },
            { 15, IniciarInterface },
            { 16, () => { } }
        };
    }

    private void AutenticarUtilizador()
    {
        do
        {
            Console.WriteLine("------------------------LOGIN--------------------------");
            Console.Write("Admin: ");
            _utilizadores.Admin = Console.ReadLine();
            Console.Write("Password: ");
            _utilizadores.Password = ReadPassword();

            if (!ValidarCredenciais(_utilizadores.Admin, _utilizadores.Password))
                Console.WriteLine("Admin ou Password incorretos. Tente novamente.");
        } while (!ValidarCredenciais(_utilizadores.Admin, _utilizadores.Password));
    }

    private bool ValidarCredenciais(string admin, string password)
    {
        return (admin, password) switch
        {
            ("Gerente", "gerente123") => true,
            ("Repositor", "repositor123") => true,
            ("Caixa", "caixa123") => true,
            _ => false
        };
    }

    private void VerificarPermissao(string role, Action action)
    {
        if (_utilizadores.Admin == role)
        {
            action.Invoke();
        }
        else
        {
            Console.WriteLine("Acesso negado!");
        }
    }

    private void VerificarPermissao(string[] roles, Action action)
    {
        if (roles.Contains(_utilizadores.Admin))
        {
            action.Invoke();
        }
        else
        {
            Console.WriteLine("Acesso negado!");
        }
    }

    private void Opcao1() => _gestaoUtilizadores.CriarRemoverUtilizador();

    private void Opcao2() => _gestaoLivros.CriarLivro();
    private void Opcao4() => _gestaoLivros.RemoverLivro();

    private void Opcao6() => _compraVendaLivros.ComprarLivro();

    private string ReadPassword()
    {
        var password = string.Empty;
        ConsoleKey key;

        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && password.Length > 0)
            {
                Console.Write("\b \b");
                password = password[0..^1];
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                password += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }

    #endregion
}
