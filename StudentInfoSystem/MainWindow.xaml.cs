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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Boolean areControlsEnabled = true;

        public List<string> StudStatusChoices { get; set; }

        // Custom constructor to pass student data
        public MainWindow(object data) : this() {
            this.DataContext = data; }
        public MainWindow()
        {
            Loaded+=FillStudStatusChoices;
            InitializeComponent();
        }

        private void FillStudStatusChoices(object sender,RoutedEventArgs e)
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr
FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)

                {
                    string s = reader.GetString(0);
                    Console.WriteLine(s);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
                    statusBox.ItemsSource = StudStatusChoices;
        }

        private void ClearAllBtn_Click(object sender, RoutedEventArgs e)
        {
           firstNameTxtBox.Text = "";
           secondNameTxtBox.Text = "";
           thirdNameTxtBox.Text = "";
           fakultetTxtBox.Text = "";
           specialnostTxtBox.Text = "";
           OKSTxtBox.Text = "";
           statusBox.SelectedItem = null;
           fakNomerTxtBox.Text = "";
           kursTxtBox.Text = "";
           potokTxtBox.Text = "";
           grupaTxtBox.Text = "";
           pfp.Source = this.Resources["DefaultImage"] as BitmapImage;
        }

        private void ToggleEnabledBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.areControlsEnabled == true)
            {
                disableAllControls();
                this.areControlsEnabled = false;
            }
            else {
                enableAllControls();
                this.areControlsEnabled = true;
            }
        }
        private void disableAllControls() {
            studentPersonalInfoGroupBox.IsEnabled = false;
            studentUniInfoGroupBox.IsEnabled = false;
        }
        private void enableAllControls() {
            studentPersonalInfoGroupBox.IsEnabled = true;
            studentUniInfoGroupBox.IsEnabled = true;
        }
    }
}
