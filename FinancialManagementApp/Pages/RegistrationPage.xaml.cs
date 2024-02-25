using FinancialManagementApp.Infrastructure.ModelDto;
using System.Windows;
using System.Windows.Controls;
using FinancialManagementApp.Interfaces;

namespace FinancialManagementApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private readonly IAuthService _authService;
        private readonly IWalletService _walletService;

        public RegistrationPage(IAuthService authService, IWalletService walletService)
        {
            InitializeComponent();

            _authService = authService;
            _walletService = walletService;
        }

        private void GoToAuthPage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
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
                MiddleName = MiddleName.Text,
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
                    this.NavigationService.GoBack();
                }
            }

            RegForm.Visibility = Visibility.Visible;
            Loader.Visibility = Visibility.Collapsed;
        }
    }
}
