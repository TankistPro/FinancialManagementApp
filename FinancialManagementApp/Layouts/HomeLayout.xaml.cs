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

        private readonly MainPage _mainPage;
        private readonly HistoryPage _historyPage;

        public HomeLayout(
            HomeLayoutVM homeLayoutVM, 
            IWalletService walletService,
            MainPage mainPage,
            HistoryPage historyPage
            )
        {

            InitializeComponent();

            _homeLayoutVM = homeLayoutVM;
            _mainPage = mainPage;
            _historyPage = historyPage;

            DataContext = _homeLayoutVM;

            if (this.sideBar.Items.Count > 0)
            {
                this.sideBar.SelectedIndex = 0;
            }

            _walletService = walletService;
        }

        private void sideBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = sideBar.SelectedItem as NavButtonControl;

            switch (item?.ComponentName)
            {
                case "MainPage": 
                    mainFraim.Navigate(_mainPage);
                    break;
                case "HistoryPage":
                    mainFraim.Navigate(_historyPage);
                    break;
                default:
                    mainFraim.Navigate(_mainPage);
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
