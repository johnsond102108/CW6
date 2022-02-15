using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace CW6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;

        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Database1.accdb");
        }

        private void AssetButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + "\n";
                data += read[1] + "\n";
                data += read[2] + "\n" + "\n";
            }
            TextBox1.Text = data;
            cn.Close();
        }

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + "\n";
                data += read[1] + " " + read[2] + "\n" + "\n";
            }
            TextBox1.Text = data;
            cn.Close();
        }
    }
}
