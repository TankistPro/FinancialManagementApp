using AutoMapper;
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
        private PeriodStatisticVM _periodStatisticVM;
        private HomeLayoutVM _homeLayoutVM;
        private MainPage _mainPage;

        private bool isEditRecord = false;

        public AddWalletHistoryWindow(
            IWalletService walletService,
            HomeLayoutVM homeLayoutVM, 
            MainPage mainPage,
            PeriodStatisticVM periodStatisticVM,
            WalletHistoryVM? editRecordVM = null)
        {
            InitializeComponent();

            _mainPage = mainPage;
            _periodStatisticVM = periodStatisticVM;
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
                _walletHistoryVM = new WalletHistoryVM()
                {
                    Id = editRecordVM.Id,
                    WalletId = editRecordVM.WalletId,
                    WalletValue = editRecordVM.WalletValue,
                    NewBalance = editRecordVM.NewBalance,
                    OldBalance = editRecordVM.OldBalance,
                    CreatedDate = editRecordVM.CreatedDate,
                    Comment = editRecordVM.Comment,
                    OperationType = editRecordVM.OperationType,
                };
                this.OperationTypeBox.SelectedIndex = editRecordVM.OperationType;
                this.Title = "Редактирование записи";
                this.WindowTitle.Text = "Редактирование транзакции";
                this.AcceptBtn.Content = "Изменить";
                this.OperationTypePanel.IsEnabled = false;
                this.OperationTypePanel.Opacity = 0.5;
            }
            else
            {
                isEditRecord = false;
                _walletHistoryVM = new WalletHistoryVM();
                _walletHistoryVM.WalletId = _homeLayoutVM.WalletVM.Id;
                this.OperationTypeBox.SelectedIndex = 0;

                this.Title = "Создание записи";
                this.WindowTitle.Text = "Добаление транзакции";
                this.AcceptBtn.Content = "Добавить";
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

            WalletHistoryVM? entity;

            if (!isEditRecord)
            {
                entity = await _walletService.CreateWalletOperation(_walletHistoryVM);
            }
            else
            {
                entity = await _walletService.UpdateWalletOperation(_walletHistoryVM);
            }

            if (entity != null)
            {
                _walletHistoryVM = entity;
                _homeLayoutVM.WalletVM.Balance = (decimal)entity.NewBalance;

                if (!isEditRecord)
                {
                    _homeLayoutVM.InsertWalletHistoryRecord(entity);
                } 
                else
                {
                    var oldRecord = _homeLayoutVM.ListWalletHistoryVM.First(x => x.Id == entity.Id);
                    var index = _homeLayoutVM.ListWalletHistoryVM.IndexOf(oldRecord);

                    if (index != -1) 
                    {
                        _homeLayoutVM.ListWalletHistoryVM[index] = entity;
                    }
                }
                

                await _mainPage.InitStatisticPlot();
                await _mainPage.InitPeriodStatistic((DateTime)_periodStatisticVM.StartDate, _periodStatisticVM.EndDate);

                this.Hide();
            }
        }
    }
}
