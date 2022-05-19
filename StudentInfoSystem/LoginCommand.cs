using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace StudentInfoSystem
{
    public class LoginCommand : ICommand
    {

        public void Execute(object parameter)
        {
            var tryLogin = parameter as TryLogin;
            var firstName = tryLogin.FirstName;
            var fNum = tryLogin.FNum;

            

              StudentData.TestStudents.ForEach(student =>
             {
                  if (student.name.Equals(firstName) && fNum.Equals(fNum))
                  {
                     MessageBox.Show(firstName, fNum);
                     Login login = new Login();
                     login.TryLog(student);
                     }
                  }); 
            }
            public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
    }
}
