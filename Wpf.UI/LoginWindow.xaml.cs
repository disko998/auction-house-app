using System.Windows;
using Wpf.ViewModel;

namespace Wpf.UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindowViewModel loginWindow;

        public LoginWindow()
        {
            InitializeComponent();           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loginWindow = new LoginWindowViewModel(tbUsername.Text.Trim(), tbPassword.Password.ToString());
            if (loginWindow.LoginValidation())
            {               
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Login failed.Please try again.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewWindow newWin = new NewWindow();
            this.Close();
            newWin.Show();
        }
    }
}
