using FinancialManagementApp.Infrastructure.ModelDto;
using System.Windows;
using System.Windows.Controls;
using FinancialManagementApp.Layouts;
using FinancialManagementApp.Services;
using FinancialManagementApp.ViewModels;
using FinancialManagementApp.Domain.Entities;

namespace FinancialManagementApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private readonly AuthService _authService;
        private readonly WalletService _walletService;
        public RegistrationPage()
        {
            InitializeComponent();

            _authService = new AuthService();
            _walletService = new WalletService();
        }

        private void GoToAuthPage(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new AuthPage();
        }

        async private void CreateUser(object sender, RoutedEventArgs e)
        {
            RegForm.Visibility = Visibility.Collapsed;
            Loader.Visibility = Visibility.Visible;

            await Task.Delay(1000); //искусственная задержка для просмотра лоадера

            var newUser = new RegistrationUserDto()
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Email = Email.Text,
                EmailConfirmed = 0,
                Password = Password.Password,
            };

            int userId = await _authService.RegistartionUser(newUser);

            if (userId > -1)
            {
                var newWallet = new WalletDto()
                {
                    Name = "Test",
                    WalletNumber = Convert.ToInt64(WalletNumber.Text),
                    Balance = Convert.ToInt32(Balance.Text),
                    UserId = userId,
                };

                int walletId = await _walletService.CreateWallet(newWallet);

                if (walletId > -1)
                {
                    var userVM = new UserVM()
                    {
                        FirstName = newUser.FirstName,
                        LastName = newUser.LastName,
                    };

                    var walletVm = new WalletVM()
                    {
                        Name = newWallet.Name,
                        Balance = newWallet.Balance,
                        WalletNumber = newWallet.WalletNumber,
                    };

                    var homeLayouVM = new HomeLayoutVM()
                    {
                        UserVM = userVM,
                        WalletVM = walletVm
                    };

                    Application.Current.MainWindow.Content = new HomeLayout(homeLayouVM);
                }
            }

            RegForm.Visibility = Visibility.Visible;
            Loader.Visibility = Visibility.Collapsed;
        }
    }
}
