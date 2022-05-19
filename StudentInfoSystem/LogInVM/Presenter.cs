using System;
using System.Windows.Input;
using UserLogin;
using System.Collections.Generic;
namespace StudentInfoSystem.LogInVM
{

    public class Presenter : ObservableObject,ICloseable
    {
        private string _username;
        private string _password;
        public Action Close { get; set; }
        public string Username { get { return _username; } set { _username = value; RaisePropertyChangedEvent("Username"); } }
        public string Password { get { return _password; } set { _password = value; RaisePropertyChangedEvent("Password"); } }
        public ICommand LogInCommand {
            get { return new DelegateCommand(doLogIn); }
        }

        void CloseWindow()
        {
            Close?.Invoke();   
        }

        private void doLogIn() {
            User test = UserData.IsUserPassCorrect(_username, _password);
                    if (test == null) {
                System.Windows.MessageBox.Show("Invalid login.");
                        return;
                   }
           
            openStudentDataWindow(test);
        }
        private void openStudentDataWindow(User dude) {
            Student target = extractStudentFromUser(dude);
            MainWindow studentData = new MainWindow(target);
            studentData.Show();
            //close login window
            CloseWindow();
        }

        private Student extractStudentFromUser(User dude) {
            int dudeId = dude.UserId;
            List<Student> testStudents = StudentData.TestStudents;
            foreach (Student stu in testStudents) {
                if (stu.StudentId == dudeId) {
                    return stu;
                }
            }
            return null;
        }

    }
}
