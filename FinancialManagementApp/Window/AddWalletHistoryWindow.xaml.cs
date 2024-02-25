using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.Interfaces;
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
        private IWalletService _walletService;
        private WalletHistoryVM _walletHistoryVM;
        private HomeLayoutVM _homeLayoutVM;

        public AddWalletHistoryWindow(IWalletService walletService, HomeLayoutVM homeLayoutVM)
        {
            InitializeComponent();

            _walletService = walletService;
            _walletHistoryVM = new WalletHistoryVM();
            _homeLayoutVM = homeLayoutVM;

            _walletHistoryVM.WalletId = _homeLayoutVM.WalletVM.Id;

            this.DataContext = _walletHistoryVM;
        }

        private void CancelAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        async private void AddWalletOperation_Click(object sender, RoutedEventArgs e)
        {
            _walletHistoryVM.OperationType = "Доход";
            _walletHistoryVM.CreatedDate = DateTime.Now;

            decimal? newBalance = await _walletService.CreateWalletOperation(_walletHistoryVM);

            if (newBalance != null)
            {
                _homeLayoutVM.WalletVM.Balance = (decimal)newBalance;
                this.Hide();
            }
        }
    }
}
