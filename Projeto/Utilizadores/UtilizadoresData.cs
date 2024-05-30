namespace Projeto.Utilizadores;

public class UtilizadoresData
{
    #region Public Properties

    public int IdUser { get; set; }
    public string Admin { get; set; }
    public string Password { get; set; }

    #endregion

    #region Constructors

    public UtilizadoresData() { }

    public UtilizadoresData(int idUser, string admin, string password)
    {
        IdUser = idUser;
        Admin = admin;
        Password = password;
    }

    #endregion
}
