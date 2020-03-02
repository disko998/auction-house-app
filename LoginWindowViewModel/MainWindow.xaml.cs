using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Wpf.ViewModel;
using System.Windows.Threading;
using System.Threading;
using Wpf.Model;

namespace Wpf.UI
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mwvm;

        public MainWindow()
        {
            InitializeComponent();

            mwvm= new MainWindowViewModel(Mediator.Instance);
            this.DataContext = mwvm;
            mwvm.IsLogin = false;
        }

        private void DoCountDown(object obj)
        {
            Product product = obj as Product;
            if (product.IsEnd == false)
            {
                int s = product.Sec;
                int m = product.Min;
                s -= 1;
                if (s == -1)
                {
                    s = 59;
                    m -= 1;
                }
                if (m == 0 && s == 0)
                {                 
                    product.DeleteProduct();
                    product.IsEnd = true;

                    if (!(product.UserId == null || product.UserId < 1))
                    {
                        product.IsSold = true;
                        product.UpdateProduct();
                        //this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate
                        //{
                        //    tbBindUser.Foreground = new SolidColorBrush(Colors.Red);
                        //    tbPrice.Foreground = new SolidColorBrush(Colors.Red);
                        //});
                    }

                    product.Time = "Auction is end!";
                    return;
                }
                product.Time = string.Format("{0}:{1}", m.ToString(), s.ToString());
                product.Min = m;
                product.Sec = s;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Product product in mwvm.ListProduct)
            {
                ThreadPool.QueueUserWorkItem(DoCountDown, product);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (mwvm.IsLogin == false)
            {
                MessageBox.Show("Please login first!");
                return;
            }
            if (lb1.SelectedIndex==-1)
            {
                return;
            }
            if (mwvm.CurrentUser.IsAdmin==true)
            {
                MessageBox.Show("Admin does not have rights to bind");
                return;
            }
            if (mwvm.CurrentProduct.IsEnd==true)
            {
                MessageBox.Show("Auction is end!");
            }
            mwvm.CurrentProduct.Min +=3;
            mwvm.CurrentProduct.Sec =0;

            mwvm.CurrentProduct.UserId = mwvm.CurrentUser.Id;
            mwvm.CurrentProduct.Price =mwvm.CurrentProduct.StartingPrice+1;
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewProduct newProduct = new NewProduct();
            newProduct.DataContext = new NewProductViewModel(Mediator.Instance);
            newProduct.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mwvm.IsLogin==false)
            {
                LoginWindow loginWin = new LoginWindow();
                loginWin.ShowDialog();
                if (loginWin.DialogResult == true)
                {
                    mwvm.CurrentUser = loginWin.loginWindow.currentUser;
                    if (mwvm.CurrentUser.IsAdmin == true)
                    {
                        btnAdd.Visibility = Visibility.Visible;
                        btnDelete.Visibility = Visibility.Visible;
                    }
                    mwvm.IsLogin = true;
                    tbWelcome.Text = "Welcome back:";
                    btnLogin.Content = "Logout";
                    return;
                }
            }
            if (mwvm.IsLogin == true)
            {
                mwvm.CurrentUser = null;
                mwvm.IsLogin = false;
                btnAdd.Visibility = Visibility.Hidden;
                btnDelete.Visibility = Visibility.Hidden;
                tbWelcome.Text = "Login to bind!";
                btnLogin.Content = "Login";
                return;

            }


        }

        private void lb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mwvm.CurrentProduct==null)
            {
                return;
            }
            if (mwvm.CurrentProduct.IsEnd==true)
            {
                btnBind.IsEnabled = false;
            }
            else
            {
                btnBind.IsEnabled = true;
            }
        }
    }
}
