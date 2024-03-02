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

        private bool isEditRecord = false;

        public AddWalletHistoryWindow(IWalletService walletService, HomeLayoutVM homeLayoutVM, WalletHistoryVM editRecordVM = null)
        {
            InitializeComponent();

            _walletService = walletService;
            
            
            _homeLayoutVM = homeLayoutVM;

            if (editRecordVM != null)
            {
                isEditRecord = true;
                _walletHistoryVM = editRecordVM;

                this.Title = "Редактирование записи";
            } 
            else
            {
                isEditRecord = false;
                _walletHistoryVM = new WalletHistoryVM();
                _walletHistoryVM.WalletId = _homeLayoutVM.WalletVM.Id;

                this.Title = "Создание записи";
            }

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
            

            if(!isEditRecord)
            {
                decimal? newBalance = await _walletService.CreateWalletOperation(_walletHistoryVM);

                if (newBalance != null)
                {
                    _walletHistoryVM.OldBalance = _homeLayoutVM.WalletVM.Balance;

                    _walletHistoryVM.NewBalance = (decimal)newBalance;
                    _homeLayoutVM.WalletVM.Balance = (decimal)newBalance;

                    _homeLayoutVM.InsertWalletHistoryRecord(_walletHistoryVM);

                    this.Hide();
                }
            }
            else
            {
                // Логика для редактирования уже созданной записи
            }  
        }
    }
}
