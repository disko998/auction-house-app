using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;

namespace Wpf.Model
{
    public class Product : INotifyPropertyChanged
    {
        #region Fileds
        //Product info
        private int _productId;
        private string _productName;
        private double _startingPrice;
        private string _productInfo;
        private bool _isSold;
        private int? _userId;

        //Auction info
        private bool isEnd;
        private double price;       
        private string time;
        private int min;
        private int sec;
        #endregion

        #region Properties
        public double Price
        {
            get { return price; }
            set
            {
                if (price == value)
                {
                    return;
                }
                price = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Price"));
            }
        }
        public string Time
        {
            get { return time; }
            set
            {
                if (time == value)
                {
                    return;
                }
                time = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Time"));
            }
        }
        public int Min
        {
            get { return min; }
            set
            {
                if (min == value)
                {
                    return;
                }
                min = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Min"));
            }
        }
        public int Sec
        {
            get { return sec; }
            set
            {
                if (sec == value)
                {
                    return;
                }
                sec = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Sec"));
            }
        }
        public bool IsEnd
        {
            get { return isEnd; }
            set
            {
                if (isEnd == value)
                {
                    return;
                }
                isEnd = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsEnd"));
            }
        }

        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (_productId == value)
                {
                    return;
                }
                _productId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ProductId"));
            }
        }
        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (_productName == value)
                {
                    return;
                }
                _productName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ProductName"));
            }
        }
        public double StartingPrice
        {
            get { return _startingPrice; }
            set
            {
                if (_startingPrice == value)
                {
                    return;
                }
                _startingPrice = value;
                OnPropertyChanged(new PropertyChangedEventArgs("StartingPrice"));
            }
        }
        public string ProductInfo
        {
            get { return _productInfo; }
            set
            {
                if (_productInfo == value)
                {
                    return;
                }
                _productInfo = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ProductInfo"));
            }
        }
        public bool IsSold
        {
            get { return _isSold; }
            set
            {
                if (_isSold == value)
                {
                    return;
                }
                _isSold = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsSold"));
            }
        }
        public int? UserId
        {
            get { return _userId; }
            set
            {
                if (_userId == value)
                {
                    return;
                }
                _userId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserId"));
            }
        }
        #endregion

        #region Const
        public Product(int productId, string productName, double startingPrice, string productInfo, bool isSold, int? userId)
        {
            _productId = productId;
            _productName = productName;
            _startingPrice = startingPrice;
            _productInfo = productInfo;
            _isSold = isSold;
            _userId = userId;

            min = 2;
            sec = 0;
            price = 0;
            isEnd = false;
        }
        public Product(string productName, double startingPrice, string productInfo, bool isSold, int? userId)
        {
            _productName = productName;
            _startingPrice = startingPrice;
            _productInfo = productInfo;
            _isSold = isSold;
            _userId = userId;

            min = 2;
            sec = 0;
            price = 0;
            isEnd = false;
        }
        public Product()
        {
            _productName = "";
            _startingPrice = 0.00;
            _productInfo = null;
            _isSold = false;
            _userId = null;

            min = 2;
            sec = 0;
            price = 0;
            isEnd = false;
        }
        #endregion

        #region Methods
        public static Product CreateProduct(SqlDataReader reader)
        {
            int productId = (int)reader[0];
            string productName = (string)reader[1];
            double startingPrice = Convert.ToDouble(reader[2]);
            string productInfo = (string)reader[3];
            bool isSold = ConvertBool((int)reader[4]);
            int? userId;/* reader[5] as int? ?? default(int);*/
            if (reader.IsDBNull(5))
            {
                userId = null;
            }
            else
            {
                userId = (int)reader[5];
            }   
            Product user = new Product(productId, productName, startingPrice, productInfo, isSold, userId);
            return user;
        }

        //convert method
        public static bool ConvertBool(int i)
        {
            if (i == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static int ConvertBackBool(bool b)
        {
            if (b == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }   
        #endregion

        #region Data access
        public void UpdateProduct()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                string message;
                conn.ConnectionString = Properties.Settings1.Default.AdminConnString;
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("UPDATE Product SET IsSold=@IsSold,UserId=@Id WHERE ProductId=@ProductId;", conn);

                    SqlParameter isSold = new SqlParameter("@IsSold", SqlDbType.Int);
                    isSold.Value = ConvertBackBool(this.IsSold);

                    SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                    id.Value = this.UserId;

                    SqlParameter myParam = new SqlParameter("@ProductId", SqlDbType.Int);
                    myParam.Value = this.ProductId;

                    command.Parameters.Add(isSold);
                    command.Parameters.Add(id);
                    command.Parameters.Add(myParam);

                    int rows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    message = "Connection faild " + ex.Message;
                }        
            }
        }
        public void Insert()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Properties.Settings1.Default.AdminConnString;
                string message = "";
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO Product(ProductName,StartingPrice,ProductInfo) VALUES(@ProductName, @StartingPrice, @ProductInfo); SELECT IDENT_CURRENT('Product');", conn);

                    SqlParameter ProductNameParam = new SqlParameter("@ProductName", SqlDbType.NVarChar);
                    ProductNameParam.Value = this.ProductName;

                    SqlParameter StartingPriceParam = new SqlParameter("@StartingPrice", SqlDbType.Money);
                    StartingPriceParam.Value = this.StartingPrice;

                    SqlParameter ProductInfoParam = new SqlParameter("@ProductInfo", SqlDbType.NVarChar);
                    ProductInfoParam.Value = this.ProductInfo;


                    command.Parameters.Add(ProductNameParam);
                    command.Parameters.Add(StartingPriceParam);
                    command.Parameters.Add(ProductInfoParam);

                    var id = command.ExecuteScalar();

                    if (id != null)
                    {
                        this.ProductId = Convert.ToInt32(id);
                    }
                }
                catch (Exception ex)
                {
                    message = "Connection faild:" + ex.Message;
                }
                
            }
        }
        public void DeleteProduct()
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = Properties.Settings1.Default.AdminConnString;
                string message = "";
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("UPDATE Product SET IsDeleted=1 WHERE ProductId=@Id", conn);

                    SqlParameter myParam = new SqlParameter("@Id", SqlDbType.Int, 11);
                    myParam.Value = this.ProductId;

                    command.Parameters.Add(myParam);

                    int rows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    message = "Connection faild" + ex.Message;
                }

            }
        }
        #endregion

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
