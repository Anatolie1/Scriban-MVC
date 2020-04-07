using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ScribanMVC
{
    public class Product
    {
        private string _name;
        private double _price;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
