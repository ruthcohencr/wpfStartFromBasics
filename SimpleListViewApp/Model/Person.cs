using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleListViewApp.Model
{
    public class Person : INotifyPropertyChanged
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
           //     OnPropertyChanged("Name");
            }
        }

        private string _familyName;

        public string FamilyName
        {
            get { return _familyName; }
            set
            {
                _familyName = value;
            //    OnPropertyChanged("FamilyName");
            }
        }

        private string _fullName;

        public string FullName
        {
            get { return FirstName + " " + FamilyName; }
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
