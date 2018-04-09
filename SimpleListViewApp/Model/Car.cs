using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleListViewApp.Model
{
    
    public class Car
    {
        private int _nubmer;

        public int Number
        {
            get { return _nubmer; }
            set { _nubmer = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
