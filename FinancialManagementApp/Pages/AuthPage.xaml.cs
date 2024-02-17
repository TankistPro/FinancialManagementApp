using FinancialManagementApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FinancialManagementApp
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void GoToRegistration(object sender, RoutedEventArgs e)
        {
           Application.Current.MainWindow.Content = new RegistrationPage();
        }

        private void AuthUser(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new HomePage();
        }
    }
}
