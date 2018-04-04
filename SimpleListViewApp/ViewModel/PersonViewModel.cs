using SimpleListViewApp.Command;
using SimpleListViewApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleListViewApp.ViewModel
{
    class PersonViewModel : INotifyPropertyChanged
    {
        public PersonViewModel()
        {
            Person = new Person() { FirstName = "Ruth", FamilyName = "Cohen" };
            Persons = new ObservableCollection<Person>();
        }

        // data from model pathing to view, through viewModel
        private Person _person;

        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                NotifyPropertyChanged("Person");
            }
        }

        private ICommand _submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if (_submitCommand == null)
                {
                    _submitCommand = new RelayCommand(SubmitExecute, CanSubmitExecute, false);
                }
                return _submitCommand;
            }
        }

        private bool CanSubmitExecute(object arg)
        {
            if (string.IsNullOrWhiteSpace(Person.FirstName) || string.IsNullOrWhiteSpace(Person.FamilyName)) 
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SubmitExecute(object parameter)
        {
            Persons.Add(Person);
        }

        //making a mechanizem to implement the list view
        private ObservableCollection<Person> _persons;
        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set {
                _persons = value;
                NotifyPropertyChanged("Persons");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
