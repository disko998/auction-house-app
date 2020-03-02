
using Wpf.Model;

namespace Wpf.ViewModel
{
    public class LoginWindowViewModel
    {
        public string userName;
        public string password;
        public UsersCollection listaUsers;
        public Users currentUser;

        public string Username
        {
            get { return userName; }
            set
            {
                if (userName == value)
                {
                    return;
                }
                userName = value;
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (password == value)
                {
                    return;
                }
                password = value;
            }
        }
        public UsersCollection ListaUsers
        {
            get { return listaUsers; }
            set
            {
                if (listaUsers == value)
                {
                    return;
                }
                listaUsers = value;
            }
        }

        public LoginWindowViewModel(string user,string pass)
        {
            ListaUsers = UsersCollection.GetAllUsers();
            Username = user;
            Password = pass;
        }

        public bool LoginValidation()
        {
            foreach (Users user in ListaUsers)
            {
                if (user.UserName==Username)
                {
                    if (user.Password.ToString()==Password.ToString())
                    {
                        currentUser = user;
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
