using FinancialManagementApp.Infrastructure.ModelDto;
using System.Windows;
using System.Windows.Controls;
using FinancialManagementApp.Interfaces;
using FinancialManagementApp.ViewModels;

namespace FinancialManagementApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private readonly IAuthService _authService;
        private readonly IWalletService _walletService;
        private RegistrationPageVM _registrationPageVM;

        public RegistrationPage(IAuthService authService, IWalletService walletService, RegistrationPageVM registrationPageVM)
        {
            InitializeComponent();

            _authService = authService;
            _walletService = walletService;

            _registrationPageVM = registrationPageVM;
            _registrationPageVM.WalletVM = new WalletVM();
            _registrationPageVM.UserVM = new UserVM();

            this.DataContext = _registrationPageVM;
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
                FirstName = _registrationPageVM.UserVM.FirstName,
                LastName = _registrationPageVM.UserVM.LastName,
                MiddleName = _registrationPageVM.UserVM.MiddleName,
                Email = Email.inputValue.Text,
                EmailConfirmed = 0,
                Password = Password.inputValue.Password,
            };

            int userId = await _authService.RegistartionUser(newUser);

            if (userId > -1)
            {
                var newWallet = new WalletDto()
                {
                    Name = "Test",
                    WalletNumber = Convert.ToInt64(_registrationPageVM.WalletVM.WalletNumber),
                    Balance = _registrationPageVM.WalletVM.Balance,
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
