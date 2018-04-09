using SimpleListViewApp.Command;
using SimpleListViewApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SimpleListViewApp.ViewModel
{
    public class CarViewModel : INotifyPropertyChanged
    {
        public CarViewModel()
        {
            Car = new Car() { Name = "Ferrary", Number = 777 };
        }

        private Car _car;
      
        public Car Car
        {
            get { return _car; }
            set
            {
                _car = value;
                OnPropertyChanged("Car");
            }
        }

        private ICommand _buttonPushed;
        public ICommand ButtonPushed
        {
            get
            {
                if (_buttonPushed == null)
                {
                    _buttonPushed = new DelegatingCommand(SayHello);
                }
                return _buttonPushed;
            }
        }

        private void SayHello()
        {
            MessageBox.Show("You pushed the button...", "This is a success message!");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
