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

    public void Opcoes()
    {
        Console.WriteLine("----------------ESCOLHA UMA OPÇÃO-------------------");
        Console.WriteLine();
        Console.WriteLine("1- Criar ou Remover Utilizadores");
        Console.WriteLine("2- Criar Livro");
        Console.WriteLine("3- Atualizar Livro");
        Console.WriteLine("4- Consultar Utilizadores");
        Console.WriteLine("5- Consultar Livros");
        Console.WriteLine("6- Comprar Livro");
        Console.WriteLine("7- Vender Livro");
        Console.WriteLine("8- Consultar Livro por Género");
        Console.WriteLine("9- Consultar Livro por Autor");
        Console.WriteLine("10- Consultar Livro por Stock");
        Console.WriteLine("11- Consultar Livro por Código");
        Console.WriteLine("12- Consultar Livro por Título");
        Console.WriteLine("13- Consultar Total Livros Vendidos e Receita");
        Console.WriteLine("14- Mudar de Utilizador");
        Console.WriteLine("15- Sair");
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------------");
    }

    public void MudarUtilizador()
    {
        MostrarOpcoes();
    }

    public void MostrarOpcoes()
    {
        AutenticarUtilizador();

        Dictionary<int, Action> opcoes = new Dictionary<int, Action>
        {
            { 1, Opcao1 },
            { 2, Opcao2 },
            { 3, _gestaoLivros.AtualizarLivro },
            { 4, _consultas.ConsultarUtilizadores },
            { 5, _consultas.ConsultarLivros },
            { 6, Opcao6 },
            { 7, _compraVendaLivros.VenderLivro },
            { 8, _consultas.ConsultarLivrosGenero },
            { 9, _consultas.ConsultarLivroAutor },
            { 10, _consultas.ConsultarStock },
            { 11, _consultas.ConsultarLivrosCod },
            { 12, _consultas.ConsultarLivrosTitulo },
            { 13, _consultas.ConsultarTotalVendidoEReceita },
            { 14, MudarUtilizador },
            { 15, () => { } }
        };

        int opcao;

        do
        {
            try
            {
                Opcoes();

                Console.Write("\n\nEscolha uma opção: ");
                opcao = Convert.ToInt32(Console.ReadLine());

                if (opcoes.ContainsKey(opcao))
                {
                    opcoes[opcao].Invoke();
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
        }
        while (opcao != 15);

        Console.Clear();
        Console.WriteLine("Tenha um bom dia!");
    }

    #endregion

    #region Private Methods

    private void AutenticarUtilizador()
    {
        do
        {
            Console.WriteLine("------------------------LOGIN--------------------------");

            Console.WriteLine("Admin: ");
            _utilizadores.Admin = Console.ReadLine();

            Console.WriteLine("Password: ");
            _utilizadores.Password = ReadPassword();

            if (!ValidarCredenciais(_utilizadores.Admin, _utilizadores.Password))
            {
                Console.WriteLine("Admin ou Password incorretos. Tente novamente.");
            }
        }
        while (!ValidarCredenciais(_utilizadores.Admin, _utilizadores.Password));
    }

    private bool ValidarCredenciais(string admin, string password)
    {
        return (admin == "Gerente" && password == "gerente123") ||
               (admin == "Repositor" && password == "repositor123") ||
               (admin == "Caixa" && password == "caixa123");
    }

    private void Opcao1()
    {
        if (_utilizadores.Admin == "Gerente" && _utilizadores.Password == "gerente123")
        {
            _gestaoUtilizadores.CriarRemoverUtilizador();
        }
        else
        {
            Console.WriteLine("Acesso negado!");
        }
    }

    private void Opcao2()
    {
        if (_utilizadores.Admin == "Repositor" && _utilizadores.Password == "repositor123")
        {
            _gestaoLivros.CriarLivro();
        }
        else
        {
            Console.WriteLine("Acesso negado!");
        }
    }

    private void Opcao6()
    {
        if (_utilizadores.Admin == "Caixa" && _utilizadores.Password == "caixa123" ||
            _utilizadores.Admin == "Gerente" && _utilizadores.Password == "gerente123")
        {
            _compraVendaLivros.ComprarLivro();
        }
        else
        {
            Console.WriteLine("Acesso negado!");
        }
    }

    private string ReadPassword()
    {
        string password = string.Empty;
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
        }
        while (key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }


    #endregion
}
