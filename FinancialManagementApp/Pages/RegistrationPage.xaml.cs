using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.Infrastructure.Repositories;
using System.Windows;
using System.Windows.Controls;
using FinancialManagementApp.Layouts;

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
            RegForm.Visibility = Visibility.Collapsed;
            Loader.Visibility = Visibility.Visible;

            await Task.Delay(1000); //искуствееная задержка для просмотра лоадера

            var newUser = new RegistrationUserDto()
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Email = Email.Text,
                EmailConfirmed = 0,
                Password = Password.Password,
            };

            int userId = await _userRepository.RegistartionUser(newUser);

            if (userId > -1)
            {
                var userWallet = new WalletDto()
                {
                    Name = "Test",
                    WalletNumber = Convert.ToInt64(WalletNumber.Text),
                    Balance = Convert.ToInt32(Balance.Text),
                    UserId = userId,
                };

                int walletId = await _walletRepository.CreateWallet(userWallet);

                if (walletId > -1)
                {
                    Application.Current.MainWindow.Content = new HomeLayout();
                }
            }
            RegForm.Visibility = Visibility.Visible;
            Loader.Visibility = Visibility.Collapsed;
        }
    }
}
