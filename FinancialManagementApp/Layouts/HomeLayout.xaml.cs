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
        private readonly HistoryPage _historyPage;

        public HomeLayout(
            HomeLayoutVM homeLayoutVM, 
            IWalletService walletService,
            HistoryPage historyPage,
            StatisticMonthVM statisticMonthVM
            )
        {

            InitializeComponent();

            _homeLayoutVM = homeLayoutVM;
            _statisticMonthVM = statisticMonthVM;

           _historyPage = historyPage;
            _walletService = walletService;

            DataContext = _homeLayoutVM;
        }

        private void sideBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = sideBar.SelectedItem as NavButtonControl;

            switch (item?.ComponentName)
            {
                case "MainPage":
                    mainFraim.Navigate(new MainPage(_statisticMonthVM, _homeLayoutVM));
                    break;
                case "HistoryPage":
                    mainFraim.Navigate(_historyPage);
                    break;
            }
        }

        private void OpenAddHistoryModal(object sender, RoutedEventArgs e)
        {
            var modal = new AddWalletHistoryWindow(_walletService, _homeLayoutVM);
            modal.ShowDialog();
        }
    }
}
