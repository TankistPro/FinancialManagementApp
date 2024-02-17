using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.Infrastructure.Repositories;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FinancialManagementApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private readonly WalletRepository _walletRepository;
        private readonly UserRepository _userRepository;
        public RegistrationPage()
        {
            InitializeComponent();

            _walletRepository = new WalletRepository();
            _userRepository = new UserRepository();
        }

        private void GoToAuthPage(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new AuthPage();
        }

        async private void CreateUser(object sender, RoutedEventArgs e)
        {
            var userWallet = new WalletDto()
            {
                Name = "Test",
                WalletNumber = 123456789,
                Balance = 50
            };

            int walletId = await _walletRepository.CreateWallet(userWallet);

            if (walletId > 0)
            {
                var newUser = new RegistrationUserDto()
                {
                    FirstName = "Иван",
                    LastName = "Мельников",
                    Email = "ivan@mail.ru",
                    Password = "admin",
                    WalletId = walletId
                };

                bool status = await _userRepository.RegistartionUser(newUser);

                if (status)
                {
                    Application.Current.MainWindow.Content = new HomePage();
                }
            }
        }
    }
}
