using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.Enums;
using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.Interfaces;
using FinancialManagementApp.Pages;
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
        private MainPage _mainPage;

        private bool isEditRecord = false;

        public AddWalletHistoryWindow(IWalletService walletService, HomeLayoutVM homeLayoutVM, MainPage mainPage, WalletHistoryVM? editRecordVM = null)
        {
            InitializeComponent();

            _mainPage = mainPage;

            _walletService = walletService;
            _homeLayoutVM = homeLayoutVM;

            this.InitWalletHistoryWindow(editRecordVM);

            this.DataContext = _walletHistoryVM;
        }

        private void InitWalletHistoryWindow(WalletHistoryVM? editRecordVM)
        {
            this.OperationTypeBox.ItemsSource = WalletOperations.walletOperationsDict.Select(x => x.Value);


            if (editRecordVM != null)
            {
                isEditRecord = true;
                _walletHistoryVM = editRecordVM;
                this.OperationTypeBox.SelectedIndex = editRecordVM.OperationType;

                this.Title = "Редактирование записи";
            }
            else
            {
                isEditRecord = false;
                _walletHistoryVM = new WalletHistoryVM();
                _walletHistoryVM.WalletId = _homeLayoutVM.WalletVM.Id;
                this.OperationTypeBox.SelectedIndex = 0;

                this.Title = "Создание записи";
            }
        }

        private void CancelAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        async private void AddWalletOperation_Click(object sender, RoutedEventArgs e)
        {
            _walletHistoryVM.OperationType = Convert.ToInt32(OperationTypeBox.SelectedIndex);
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
                    _mainPage.InitStatisticPlot();

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
