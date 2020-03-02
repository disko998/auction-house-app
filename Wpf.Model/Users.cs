using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Wpf.Model
{
    public class Users: INotifyPropertyChanged,INotifyDataErrorInfo
    {
        #region Fields
        private int _id;
        private string _userName;
        private string _password;
        private bool? _isAdmin;

        public Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
        private UsersCollection listaUsers;
        #endregion

        #region Prop
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id==value)
                {
                    return;
                }
                _id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Id"));
            }
        }
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName == value)
                {
                    return;
                }
                _userName = value;

                listaUsers = UsersCollection.GetAllUsers();
                List<string> errors = new List<string>();
                bool valid = true;

                if (value==null || value=="")
                {
                    errors.Add("UserName can't be empty!");
                    SetErrors("UserName", errors);
                    valid = false;
                }
                if (double.TryParse(value,out double i))
                {
                    errors.Add("Username can't be only numbers");
                    SetErrors("UserName", errors);
                    valid = false;
                }
                foreach (Users user in listaUsers)
                {
                    if (user.UserName==value)
                    {
                        errors.Add("This Username is alredy exist");
                        SetErrors("UserName", errors);
                        valid = false;
                    }
                }
                if (valid)
                {
                    ClearErrors("UserName");
                }

                OnPropertyChanged(new PropertyChangedEventArgs("UserName"));
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password == value)
                {
                    return;
                }
                _password = value;

                List<string> errors = new List<string>();
                bool valid = true;

                if (value == null || value == "")
                {
                    errors.Add("Password can't be empty!");
                    SetErrors("Password", errors);
                    valid = false;
                }
                if (valid)
                {
                    ClearErrors("Password");
                }

                OnPropertyChanged(new PropertyChangedEventArgs("Password"));
            }
        }
        public bool? IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                if (_isAdmin == value)
                {
                    return;
                }
                _isAdmin = value;

                List<string> errors = new List<string>();
                bool valid = true;
                if (value == null)
                {
                    errors.Add("You mast select admin!");
                    SetErrors("IsAdmin", errors);
                    valid = false;
                }
                if (valid)
                {
                    ClearErrors("IsAdmin");
                }

                OnPropertyChanged(new PropertyChangedEventArgs("IsAdmin"));
            }
        }
        public bool HasErrors
        {
            get
            {
                return (errors.Count > 0);
            }
        }
        #endregion

        #region Const
        public Users(int id,string userName,string password,bool? isAdmin)
        {
            _id = id;
            _userName = userName;
            _password = password;
            _isAdmin = isAdmin;
        }
        public Users(string userName, string password, bool? isAdmin)
        {
            _userName = userName;
            _password = password;
            _isAdmin = isAdmin;
        }
        public Users()
        {
            _userName = "";
            _password = "";
            _isAdmin = null;
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        #endregion

        #region Methods
        //metoda za event property changed
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        //convert metoda
        public static bool? ConvertBool(int i)
        {
            if (i==0)
            {
                return false;
            }
            else if (i==1)
            {
                return true;
            }
            else
            {
                return null;
            }
        }
        public static int? ConvertBackBool(bool? b)
        {
            if (b==true)
            {
                return 1;
            }
            else if (b==false)
            {
                return 0;
            }
            else
            {
                return null;
            }
        }
        //metoda za kreiranje istance User
        public static Users CreateUser(SqlDataReader reader)
        {
            int id = (int)reader["Id"];
            string userN = (string)reader["UserName"];
            string pass = (string)reader["UserPass"];
            bool? admin = ConvertBool((int)reader["IsAdmin"]);

            Users user = new Users(id, userN, pass, admin);
            return user;
        }
        //error metode
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return (errors.Values);
            }
            else
            {
                if (errors.ContainsKey(propertyName))
                {
                    return (errors[propertyName]);
                }
                else
                {
                    return null;
                }
            }
        }
        private void SetErrors(string propertyName, List<string> propertyErrors)
        {
            errors.Remove(propertyName);
            errors.Add(propertyName, propertyErrors);
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        private void ClearErrors(string propertyName)
        {
            errors.Remove(propertyName);
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        #endregion

        #region Data Access     
        public void Insert()
        {
            string message = "";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Properties.Settings1.Default.AdminConnString;
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO Users(UserName, UserPass, isAdmin) VALUES(@UserName, @Password, @IsAdmin); SELECT IDENT_CURRENT('Users');", conn);

                    SqlParameter userNameParam = new SqlParameter("@UserName", SqlDbType.NVarChar);
                    userNameParam.Value = this.UserName;

                    SqlParameter password = new SqlParameter("@Password", SqlDbType.NVarChar);
                    password.Value = this.Password;

                    SqlParameter isAdmin = new SqlParameter("@IsAdmin", SqlDbType.SmallInt);
                    isAdmin.Value = ConvertBackBool(this.IsAdmin);


                    command.Parameters.Add(userNameParam);
                    command.Parameters.Add(password);
                    command.Parameters.Add(isAdmin);

                    var id = command.ExecuteScalar();

                    if (id != null)
                    {
                        this.Id = Convert.ToInt32(id);
                    }
                }
                catch (Exception ex)
                {
                    message = "Connection faild:" + ex.Message;
                }
            }
        }
        #endregion
    }
}
