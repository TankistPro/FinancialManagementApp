using AutoMapper;
using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.Interfaces;
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
using System.Windows.Navigation;

namespace FinancialManagementApp
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private readonly IWalletService _walletService;
        private readonly IAuthService _authService;
        private readonly RegistrationPage _registrationPage;
        private readonly HomeLayout _homeLayout;
        private HomeLayoutVM _homeLayoutVM;

        public AuthPage(
            IAuthService authService,
            IWalletService walletService,
            HomeLayoutVM homeLayoutVM,
            RegistrationPage registrationPage,
            HomeLayout homeLayout
            )
        {
            InitializeComponent();

            _homeLayoutVM = homeLayoutVM;
            
            _registrationPage = registrationPage;
            _homeLayout = homeLayout;

            _authService = authService;
            _walletService = walletService;
        }

        private void GoToRegistration(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(_registrationPage);
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

                UserVM user = await _authService.LoginUser(email.Text, password.Password);
                
                if (user != null)
                {
                    WalletVM wallet = await _walletService.GetUserWallet(user.Id);

                    _homeLayoutVM.InitVM(user, wallet, null);
                    _homeLayout.sideBar.SelectedIndex = 0;

                    this.NavigationService.Navigate(_homeLayout);
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
