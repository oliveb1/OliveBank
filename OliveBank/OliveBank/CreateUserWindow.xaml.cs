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
using OliveBank.sqlHandler;


namespace OliveBank
{
    /// <summary>
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        public CreateUserWindow()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Authentication authentication = new Authentication();
            authentication.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            sqlAccountHandlers accountHandler = new sqlAccountHandlers();
            accountHandler.CreateUserAccount(txtUsername.Text, txtPassword.Password, txtFirstName.Text, txtLastName.Text, txtEmail.Text);
            MessageBox.Show("Account Created!");
        }
    }
}
