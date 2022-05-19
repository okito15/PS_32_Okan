using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        public  Student student1;
        public Login()
        {
            InitializeComponent();
            DataContext = new TryLogin();
        }
        public void TryLog(Student student)
        {
            StudentData.userExists = true;
            student1 = student;
            Close();
        }
        public void ButtonLogin(object sender, RoutedEventArgs e) {
           // var name = nameBox.Text;
           // var pass = passBox.Password.ToString();
           // StudentData.TestStudents.ForEach(student =>
           // {
           //     if (student.name.Equals(name) && pass.Equals(student.facultyNumber))
           //     {
            //        StudentData.userExists = true;
            //        StudentData.username = name;
            //        StudentData.password = pass;
           //         student1 = student;
// Close();
            //    }
          //  });
               
        }
    }
}
