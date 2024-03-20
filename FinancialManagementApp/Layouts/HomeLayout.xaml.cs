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
        private StatisticMonthVM _statisticMonthVM;
        private PeriodStatisticVM _periodStatisticVM;
        private HistoryPage _historyPage;
        private MainPage _mainPage;

        public HomeLayout(
            HomeLayoutVM homeLayoutVM, 
            IWalletService walletService,
            HistoryPage historyPage,
            MainPage mainPage,
            StatisticMonthVM statisticMonthVM,
            PeriodStatisticVM periodStatisticVM
            )
        {

            InitializeComponent();

            _homeLayoutVM = homeLayoutVM;
            _statisticMonthVM = statisticMonthVM;
            _periodStatisticVM = periodStatisticVM;
            _historyPage = historyPage;
            _mainPage = mainPage;
            
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
                    mainFraim.Navigate(new DirectoryPage());
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
