using Project.Lists;

namespace Project.Users
{
    public class UsersManagement
    {
        #region Public Properties

        public string Option { get; set; }

        #endregion

        #region Private Properties

        private readonly BooksUsersLists _lists;

        #endregion

        #region Constructor

        public UsersManagement(BooksUsersLists lists) => _lists = lists;

        #endregion

        #region Public Methods

        public void CreateRemoveUser()
        {
            while (true)
            {
                Console.Write("Choose an option (Create, Remove, Quit): ");
                Option = Console.ReadLine();

                switch (Option)
                {
                    case "Create":
                        CreateUser();
                        break;

                    case "Remove":
                        RemoveUser();
                        break;

                    case "Quit":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        #endregion

        #region Private Methods

        private void CreateUser()
        {
            UsersData newUser = new();

            Console.Write("New Id (0 to cancel): ");

            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("Invalid Id!");
                return;
            }

            newUser.UserId = id;

            Console.Write("New Admin: ");
            newUser.Admin = Console.ReadLine();

            Console.Write("New Password: ");
            newUser.Password = Console.ReadLine();

            _lists.Users.Add(newUser);

            Console.WriteLine("User created successfully!");
            Console.WriteLine($"Admin: {newUser.Admin} | Password: {newUser.Password}");
        }

        private void RemoveUser()
        {
            Console.Write("Enter the ID of the user you want to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int idRemove))
            {
                Console.WriteLine("Invalid Id!");
                return;
            }

            var user = _lists.Users.Find(u => u.UserId == idRemove);

            if (user != null)
            {
                _lists.Users.Remove(user);
                Console.WriteLine("User removed successfully!");
            }
            else Console.WriteLine("User not found with that ID.");
        }

        #endregion
    }
}
