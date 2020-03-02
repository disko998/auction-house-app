using System;
using System.Windows;
using Wpf.ViewModel;

namespace Wpf.UI
{
    /// <summary>
    /// Interaction logic for NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        public NewProduct()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewProductViewModel npvm = (NewProductViewModel)DataContext;
            if (npvm.NewProduct == null)
            {
                MessageBox.Show("Check you inputs!");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Product name can't be empty");
                return;
            }
            if (!double.TryParse(tbCena.Text.Trim(),out double d))
            {
                MessageBox.Show("Wrong price:" + d);
                return;
            }
            npvm.NewProduct.ProductName = tbName.Text;
            npvm.NewProduct.StartingPrice = Convert.ToDouble(tbCena.Text);
            npvm.NewProduct.ProductInfo = tbInfo.Text;

            npvm.NewProduct.Insert();
            npvm.mediator.Notify("ProductChange", npvm.NewProduct);
            MessageBox.Show("Your product is on auction!");
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
