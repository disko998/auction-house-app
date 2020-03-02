using System;
using System.Globalization;
using System.Windows.Data;

namespace Wpf.Model
{ 
    public class PriceConverter:IValueConverter
    {
        private ProductCollection lista = ProductCollection.GetAllProduct();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double price = (double)value;
            foreach (Product product in lista)
            {
                if (price==0)
                {
                    return "";
                }
            }
            return price;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string price = value.ToString();
            foreach (Product product in lista)
            {
                if (price=="")
                {
                    return product.Price;
                }
            }
            return price;
        }
    }
}
