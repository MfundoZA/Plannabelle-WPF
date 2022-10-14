using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Plannabelle_WPF.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginViewModel loginViewModel;

        public LoginWindow()
        {
            InitializeComponent();
            loginViewModel = new LoginViewModel();
            DataContext = loginViewModel;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Get login details from user
            string username = txtUsername.Text;
            string password = loginViewModel.HashPassword(txtPassword.Password);
            bool userFound = false;

            // Create User object from details provided
            User user = new User(username, password);

            // Compare User object to users in the users textfile and see if a match is found
            IEnumerable<User> Users = loginViewModel.ReadUsersfromDatabase();

            foreach (User student in Users)
            {
                if (user.Username == student.Username && user.HashedPassword == student.HashedPassword)
                {
                    MessageBox.Show("Account found! Moving to home page.");
                    BaseViewModel.User = student;
                    userFound = true;

                    new MainWindow().Show();
                    this.Close();
                    break;
                }
            }

            // If a match is not found display error
            if (userFound == false)
            {
                MessageBox.Show("Error, details incorrect! Please try again.");
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Get login details from user
            string username = txtUsername.Text;
            string password = loginViewModel.HashPassword(txtPassword.Password);

            // Create User object from details provided
            User user = new User(username, password);

            // Write user to textfile
            if (loginViewModel.WriteUserToDatabase(user).Result == false)
            {
                MessageBox.Show("Your account could not be created! Please try again later.");
            }
            else
            {
                MessageBox.Show("Your account has been created! Please login.");
            }
        }
    }
}
