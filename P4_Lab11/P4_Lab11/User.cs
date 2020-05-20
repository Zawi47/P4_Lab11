using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_Lab11
{
    class User:INotifyPropertyChanged
    {
        public User(int iD, string login, int points)
        {
            ID = iD;
            Login = login;
            Points = points;
        }

        public int ID { get; set; }
        public string Login { get; set; }
        private int _points;
        public int Points {
            get {
                return _points;
            }
            set
            {
                if (_points != value)
                {
                    _points = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Points"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
