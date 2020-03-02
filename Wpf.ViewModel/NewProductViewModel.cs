using Wpf.Model;
using System.ComponentModel;

namespace Wpf.ViewModel
{
    public class NewProductViewModel : INotifyPropertyChanged
    {
        private Product newProduct;
        public Mediator mediator;

        public Product NewProduct
        {
            get { return newProduct; }
            set
            {
                if (newProduct == value)
                {
                    return;
                }
                newProduct = value;
                OnPropertyChanged(new PropertyChangedEventArgs("NewProduct"));
            }
        }

        public NewProductViewModel(Mediator mediator)
        {
            this.mediator = mediator;
            NewProduct = new Product();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }


    }

}
