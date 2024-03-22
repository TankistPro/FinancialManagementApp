using AutoMapper;
using FinancialManagementApp.Controls;
using FinancialManagementApp.Interfaces;
using FinancialManagementApp.Pages;
using FinancialManagementApp.Pages.Home;
using FinancialManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace FinancialManagementApp.Layouts
{
    /// <summary>
    /// Логика взаимодействия для HomeLayout.xaml
    /// </summary>
    public partial class HomeLayout : Page
    {
        private IWalletService _walletService;
        private HomeLayoutVM _homeLayoutVM;
        private PeriodStatisticVM _periodStatisticVM;
        private HistoryPage _historyPage;
        private MainPage _mainPage;
        private DirectoryPage _directoryPage;

        public HomeLayout(
            HomeLayoutVM homeLayoutVM, 
            IWalletService walletService,
            HistoryPage historyPage,
            MainPage mainPage,
            DirectoryPage directoryPage,
            PeriodStatisticVM periodStatisticVM
            )
        {

            InitializeComponent();

            _homeLayoutVM = homeLayoutVM;
            _periodStatisticVM = periodStatisticVM;
            _historyPage = historyPage;
            _mainPage = mainPage;
            _directoryPage = directoryPage;
            
            _walletService = walletService;

            DataContext = _homeLayoutVM;
        }

        private void sideBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = sideBar.SelectedItem as NavButtonControl;

            switch (item?.ComponentName)
            {
                case "MainPage":
                    _mainPage.InitPage();
					mainFraim.Navigate(_mainPage);
                    break;
                case "HistoryPage":
                    mainFraim.Navigate(_historyPage);
                    break;
                case "DirectoryPage":
                    mainFraim.Navigate(_directoryPage);
                    break;
            }
        }

        private void OpenAddHistoryModal(object sender, RoutedEventArgs e)
        {
            var modal = new AddWalletHistoryWindow(_walletService, _homeLayoutVM, _mainPage, _periodStatisticVM);
            modal.ShowDialog();
        }
    }
}
