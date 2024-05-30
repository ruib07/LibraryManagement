namespace Project.Users;

public class UsersData
{
    #region Public Properties

    public int UserId { get; set; }
    public string Admin { get; set; }
    public string Password { get; set; }

    #endregion

    #region Constructors

    public UsersData() { }

    public UsersData(int userId, string admin, string password)
    {
        UserId = userId;
        Admin = admin;
        Password = password;
    }

    #endregion
}
