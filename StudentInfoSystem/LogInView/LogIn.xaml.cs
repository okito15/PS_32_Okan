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
using UserLogin;
namespace StudentInfoSystem.LogInView
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            if (DataContext is ICloseable vm) {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }
        private void TestStudentsIfEmpty(object sender, RoutedEventArgs e) {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            if (countStudents == 0)
            {
                MessageBox.Show("True");
                CopyTestStudents();
            }
            else {
            MessageBox.Show("False");
            }
        }
        private void CopyTestStudents() {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);
            }
            context.SaveChanges();
            MessageBox.Show("TestStudents were added to the database");
        }
    }
}
