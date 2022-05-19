using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using StudentInfoSystem;
using System.Windows;

namespace StudentInfoSystem
{
    public class TryLogin : INotifyPropertyChanged

    {
        string _firstName = "";
        string _fNum = "";

        LoginCommand _loginCommand = new LoginCommand();
        public LoginCommand LoginCommand
        {

            get {
            
                return _loginCommand; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }
        public string FNum
        {
            get { return _fNum; }
            set
            {
                if (_fNum != value)
                {
                    _fNum = value;
                    OnPropertyChanged("FNum");
                }
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
