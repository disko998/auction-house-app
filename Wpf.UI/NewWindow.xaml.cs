using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Wpf.ViewModel;

namespace Wpf.UI
{
    /// <summary>
    /// Interaction logic for NewWindow.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
        private NewWindowViewModel nwvm;

        public NewWindow()
        {
            InitializeComponent();
            nwvm = new NewWindowViewModel();
            this.DataContext = nwvm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NewWindowViewModel newWindowVM = (NewWindowViewModel)DataContext;
            newWindowVM.Done += NewWindowVM_Done;
        }

        private void NewWindowVM_Done(object sender, NewWindowViewModel.DoneEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        private void Valid_Error(object sender, ValidationErrorEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (e.Action == ValidationErrorEventAction.Added)
            {
                tb.ToolTip = e.Error.ErrorContent.ToString();
            }           
        }

        private void Checked(object sender, RoutedEventArgs e)
        {
            if (rbDa.IsChecked == true)
            {
                nwvm.NewUser.IsAdmin = true;
            }
            else
            {
                nwvm.NewUser.IsAdmin = false;
            }
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(tbPass1.Text==tbPass2.Text))
            {
                tbPass2.BorderBrush = new SolidColorBrush(Colors.Red);
                tbPass2.ToolTip = "Password thas not match!";
            }
            else
            {
                tbPass2.BorderBrush = new SolidColorBrush(Colors.LightGreen);
                tbPass2.ToolTip = "Password are match!";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
