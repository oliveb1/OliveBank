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
using System.Data.SqlClient;

namespace OliveBank
{
    /// <summary>
    /// Interaction logic for Authentication.xaml
    /// </summary>
    public partial class Authentication : Window
    {
        public string constring = "Data Source=LAPTOP-EH8S1KN2\\SQLEXPRESS;Initial Catalog=OliveBank;Integrated Security=True";
        public Authentication()
        {
            InitializeComponent();

            passBox.Password = "Password";
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if(usernameTxt.Text=="banker" && passBox.Password == "Admin")
            {
                MainWindow mainWin = new MainWindow();
                mainWin.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("The username or password is incorrect.");
                usernameTxt.Text = "Username";
                passBox.Password = "Password";
                passBox.GotFocus += passBox_GotFocus;
            }
        }

        private void usernameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = string.Empty;
            textBox.GotFocus -= usernameTxt_GotFocus;
        }

        private void usernameTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if(string.IsNullOrEmpty(textBox.Text) || string.IsNullOrWhiteSpace(textBox.Text)){
                textBox.Text = "Username";
                textBox.GotFocus += usernameTxt_GotFocus;
            }
        }

        private void passBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
            passwordBox.Password = string.Empty;
            passwordBox.GotFocus -= passBox_GotFocus;
        }

        private void passBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
            if(string.IsNullOrEmpty(passwordBox.Password) || string.IsNullOrWhiteSpace(passwordBox.Password))
            {
                passwordBox.Password = "Password";
                passwordBox.GotFocus += passBox_GotFocus;
            }
        }

        private void createUserBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateUserWindow createUserWindow = new CreateUserWindow();
            createUserWindow.Show();
            this.Close();
          /*  SqlConnection con = new SqlConnection(constring);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "insert into employeeLogin(username, password)values('" + usernameTxt.Text.ToString() + "','" + passBox.Password.ToString() + "')";
                SqlCommand cmd = new SqlCommand(q,con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Created!");
            }
            con.Close();*/
        }
    }
}
