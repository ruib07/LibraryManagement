using Projeto.Livros;
using Projeto.Utilizadores;

namespace Projeto.Listas;

public class ListasLivrosUsers
{
    #region Public Properties

    public List<UtilizadoresData> Utilizadores = new List<UtilizadoresData>();
    public List<LivrosData> Livros = new List<LivrosData>();

    #endregion

    #region Constructor

    public ListasLivrosUsers()
    {
        Utilizadores.Add(new UtilizadoresData(1, "Gerente", "gerente123"));
        Utilizadores.Add(new UtilizadoresData(2, "Repositor", "repositor123"));
        Utilizadores.Add(new UtilizadoresData(3, "Caixa", "caixa123"));

        Livros.Add(new LivrosData(1, "A44S", "Com o Humor Não se Brinca", "Nelson Nunes", "Comédia", 123456789, 22, (float)19.99, (float)0.23));
        Livros.Add(new LivrosData(2, "A55", "O Exorcista", "William Peter Blatty", "Terror", 987654321, 25, (float)9.99, (float)0.23));
        Livros.Add(new LivrosData(3, "B32", "Moby Dick", "Herman Melville", "Ação", 123454321, 20, (float)4.99, (float)0.06));
    }

    #endregion
}
