using AutoMapper;
using FinancialManagementApp.Infrastructure.Interfaces;
using FinancialManagementApp.Interfaces;
using FinancialManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FinancialManagementApp.Pages.Home
{
    /// <summary>
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        private readonly IWalletService _walletService;
        private ICategoryService _categoryService;
        private HomeLayoutVM _homeLayoutVM;
        private PeriodStatisticVM _periodStatisticVM;
        private MainPage _mainPage;
        private DirectoryPageVM _directoryPageVM;

        public HistoryPage(
            HomeLayoutVM homeLayoutVM,
            MainPage mainPage,
            PeriodStatisticVM periodStatisticVM,
            DirectoryPageVM directoryPageVM,
            ICategoryService categoryService,
            IWalletService walletService)
        {
            InitializeComponent();

            _mainPage = mainPage;
            _periodStatisticVM = periodStatisticVM;
            _walletService = walletService;
            _homeLayoutVM = homeLayoutVM;
            _directoryPageVM = directoryPageVM;
            _categoryService = categoryService;

            this.Loaded += (e, s) => InitHistory();
        }

        async private void InitHistory()
        {
            WalletHistoryTable.ItemsSource = _homeLayoutVM.ListWalletHistoryVM;
        }

        private void EditRecord_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WalletHistoryVM currentRecord = (WalletHistoryTable.SelectedItem as WalletHistoryVM);

            if (currentRecord != null)
            {
                var modal = new AddWalletHistoryWindow(_walletService, _homeLayoutVM, _mainPage, _periodStatisticVM, _directoryPageVM, _categoryService, currentRecord);
                modal.ShowDialog();
            }
        }
    }
}
