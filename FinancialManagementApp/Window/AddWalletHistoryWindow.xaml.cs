using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.Services;
using FinancialManagementApp.ViewModels;
using System.Windows;


namespace FinancialManagementApp
{
    /// <summary>
    /// Логика взаимодействия для AddWalletHistoryWindow.xaml
    /// </summary>
    public partial class AddWalletHistoryWindow : Window
    {
        private WalletService _walletService;
        private WalletHistoryVM _walletHistoryVM { get; set; }
        private HomeLayoutVM _homeLayoutVM;
        public AddWalletHistoryWindow(WalletHistoryVM walletHistoryVM, HomeLayoutVM homeLayoutVM)
        {
            InitializeComponent();

            _walletService = new WalletService();

            _walletHistoryVM = walletHistoryVM;
            _homeLayoutVM = homeLayoutVM;

            this.DataContext = _walletHistoryVM;
        }

        private void CancelAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        async private void AddWalletOperation_Click(object sender, RoutedEventArgs e)
        {
            var newOperation = new WalletHistoryDto()
            {
                WalletId = _walletHistoryVM.WalletId,
                OperationType = _walletHistoryVM.OperationType,
                Value = _walletHistoryVM.WalletValue,
                Comment = _walletHistoryVM.Comment
            };

            decimal? newBalance = await _walletService.CreateWalletOperation(newOperation);

            if (newBalance != null)
            {
                _homeLayoutVM.WalletVM.Balance = (decimal)newBalance;

                this.Close();
            }
        }
    }
}
