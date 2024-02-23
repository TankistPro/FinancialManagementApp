using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.Layouts;
using FinancialManagementApp.Pages;
using FinancialManagementApp.Services;
using FinancialManagementApp.ViewModels;
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
        private readonly AuthService _authService;
        private readonly WalletService _walletService;
        public AuthPage()
        {
            InitializeComponent();

            _authService = new AuthService();
            _walletService = new WalletService();
        }

        private void GoToRegistration(object sender, RoutedEventArgs e)
        {
           Application.Current.MainWindow.Content = new RegistrationPage();
        }

        async private void AuthUser(object sender, RoutedEventArgs e)
        {
            ErrorBlock.Visibility = Visibility.Collapsed;

            
            string Email = email.Text;
            string Password = password.Password;

           

            if (String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(Password)) 
            {
                ErrorBlock.Text = "Заполните поля";
            } 
            else
            {
                Loader.Visibility = Visibility.Visible;
                AuthForm.Visibility = Visibility.Hidden;

                await Task.Delay(1000); //искусственная задержка для просмотра лоадера

                UserDto user = await _authService.LoginUser(email.Text, password.Password);
                

                if (user != null)
                {
                    WalletDto wallet = await _walletService.GetUserWallet(user.Id);

                    var userVM = new UserVM()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        MiddleName = user.MiddleName,
                    };

                    var walletVm = new WalletVM()
                    {
                        Name = wallet.Name,
                        Balance = wallet.Balance,
                        WalletNumber = wallet.WalletNumber,
                    };

                    var homeLayouVM = new HomeLayoutVM()
                    {
                        UserVM = userVM,
                        WalletVM = walletVm
                    };

                    Application.Current.MainWindow.Content = new HomeLayout(homeLayouVM);
                }
                else
                {
                    ErrorBlock.Text = "Пользователя с таким Email или паролем не существует в системе";
                }
            }

            ErrorBlock.Visibility = Visibility.Visible;

            Loader.Visibility = Visibility.Hidden;
            AuthForm.Visibility = Visibility.Visible;
        }
    }
}
