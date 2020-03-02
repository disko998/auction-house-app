using System.ComponentModel;
using Wpf.Model;
using System.Windows.Input;


namespace Wpf.ViewModel
{
     public class MainWindowViewModel :INotifyPropertyChanged
    {
        #region Fields
        private Users currentUser;
        private ProductCollection listProduct;
        private Product currentProduct;
        private ICommand deleteCommand;
        private Mediator mediator;
        private bool isLogin;
        #endregion

        #region Properties
        public Product CurrentProduct
        {
            get { return currentProduct; }
            set
            {
                if (currentProduct == value)
                {
                    return;
                }
                currentProduct = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentProduct"));
            }
        }
        public Users CurrentUser
        {
            get { return currentUser; }
            set
            {
                if (currentUser == value)
                {
                    return;
                }
                currentUser = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentUser"));
            }
        }
        public ProductCollection ListProduct
        {
            get { return listProduct; }
            set
            {
                if (listProduct == value)
                {
                    return;
                }
                listProduct = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ListProduct"));
            }
        }
        public ICommand DeleteCommand
        {
            get { return deleteCommand; }
            set
            {
                if (deleteCommand == value)
                {
                    return;
                }
                deleteCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DeleteCommand"));
            }
        }
        public bool IsLogin
        {
            get { return isLogin; }
            set
            {
                if (isLogin == value)
                {
                    return;
                }
                isLogin = value;
            }
        }
        #endregion

        #region Constructors
        public MainWindowViewModel(Mediator mediator)
        {
            this.mediator = mediator;
            ListProduct = ProductCollection.GetAllProduct();
            DeleteCommand = new Komanda(DeleteExecute, CanDelete);
            CurrentUser = null;
            CurrentProduct = null;
            mediator.Register("ProductChange", ProductChange);
        }
        public MainWindowViewModel()
        {
            ListProduct = ProductCollection.GetAllProduct();
            DeleteCommand = new Komanda(DeleteExecute, CanDelete);
            CurrentUser = null;
            CurrentProduct = null;
        }
        #endregion

        #region Methods
        private void ProductChange(object obj)
        {
            Product product = (Product)obj;

            int index = ListProduct.IndexOf(product);

            if (index != -1)
            {
                ListProduct.RemoveAt(index);
                ListProduct.Insert(index, product);
            }
            else
            {
                ListProduct.Add(product);
            }
        }

        void DeleteExecute(object obj)
        {
            CurrentProduct.DeleteProduct();
            ListProduct.Remove(CurrentProduct);
        }
        bool CanDelete(object obj)
        {

            if (CurrentProduct == null) return false;

            return true;
        }
        #endregion

        #region Other
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        #endregion
    }
}
