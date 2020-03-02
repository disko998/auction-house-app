using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Wpf.Model
{
     public class ProductCollection : ObservableCollection<Product>
    {
        public static ProductCollection GetAllProduct()
        {
            ProductCollection listaProduct = new ProductCollection();
            Product product = null;
            string message = "";

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Properties.Settings1.Default.AdminConnString;
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Product WHERE IsDeleted=0;", conn);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product = Product.CreateProduct(reader);
                            listaProduct.Add(product);
                        }
                    }
                }
                catch (Exception ex)
                {
                    message = "Connection faild:" + ex.Message;
                }            
            }
            return listaProduct;
        }
    }
}
