using System;
using System.Windows.Input;
using Wpf.Model;
using System.ComponentModel;

namespace Wpf.ViewModel
{
    public class NewWindowViewModel:INotifyPropertyChanged
    {
        private Users newUser;
        private ICommand saveCommand;
        private string passValid;

        public Users NewUser
        {
            get { return newUser; }
            set
            {
                if (newUser == value)
                {
                    return;
                }
                newUser = value;
                OnPropertyChanged(new PropertyChangedEventArgs("NewUser"));
            }
        }
        public ICommand SaveCommand
        {
            get { return saveCommand; }
            set
            {
                if (saveCommand == value)
                {
                    return;
                }
                saveCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SaveCommand"));
            }
        }
        public string PassValid
        {
            get { return passValid; }
            set
            {
                if (passValid == value)
                {
                    return;
                }
                passValid = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PassValid"));
            }
        }

        public NewWindowViewModel()
        {
            SaveCommand = new Komanda(SaveExecute, CanExecute);
            NewUser = new Users();
        }

        void SaveExecute(object obj)
        {
            if (NewUser != null && !NewUser.HasErrors && passValid == NewUser.Password)
            {
                NewUser.Insert();
                OnDone(new DoneEventArgs("Success registration.You can login now!"));
            }
            else
            {
                OnDone(new DoneEventArgs("Check you inputs!"));
            }
        }
        bool CanExecute(object obj)
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        public delegate void DoneEventHandler(object sender, DoneEventArgs e);
        public class DoneEventArgs : EventArgs
        {
            private string message;

            public string Message
            {
                get { return message; }
                set
                {
                    if (message == value)
                    {
                        return;
                    }
                    message = value;
                }
            }

            public DoneEventArgs(string message)
            {
                this.message = message;
            }
        }
        public event DoneEventHandler Done;
        public void OnDone(DoneEventArgs e)
        {
            if (Done != null)
            {
                Done(this, e);
            }
        }
    }
}
