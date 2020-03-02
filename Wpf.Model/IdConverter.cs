using System;
using System.Globalization;
using System.Windows.Data;

namespace Wpf.Model
{
    public class IdConverter : IValueConverter
    {
        private UsersCollection lista = UsersCollection.GetAllUsers();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {           
            int? id = (int?)value;
            foreach (Users user in lista)
            {
                if (user.Id==id)
                {
                    return user.UserName;
                }
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string userName = value.ToString();

            foreach (Users user in lista)
            {
                if (user.UserName==userName)
                {
                    return user.Id;
                }
            }
            return null; 
        }
    }
}
