using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Wpf.Model
{
     public class UsersCollection :ObservableCollection<Users>
    {
        public static UsersCollection GetAllUsers()
        {
            UsersCollection listaUsers = new UsersCollection();
            Users user = null;
            string message = "";

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Properties.Settings1.Default.AdminConnString;
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Users;", conn);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = Users.CreateUser(reader);
                            listaUsers.Add(user);
                        }
                    }
                }
                catch (Exception ex)
                {
                    message = "Connection faild:" + ex.Message;
                }             
            }
                return listaUsers;

            
        }
    }
}
