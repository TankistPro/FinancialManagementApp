using FinancialManagementApp.Controls;
using FinancialManagementApp.Interfaces;
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

        public HomeLayout(HomeLayoutVM homeLayoutVM, IWalletService walletService)
        {

            InitializeComponent();

            _homeLayoutVM = homeLayoutVM;

            DataContext = _homeLayoutVM;

            if (this.sideBar.Items.Count > 0)
            {
                this.sideBar.SelectedIndex = 0;
            }

            _walletService = walletService;
        }

        private void sideBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = sideBar.SelectedItem as NavButtonControl;

            mainFraim.Navigate(selected.NavLink);
        }

        private void OpenAddHistoryModal(object sender, RoutedEventArgs e)
        {
            var modal = new AddWalletHistoryWindow(_walletService, _homeLayoutVM);
            modal.ShowDialog();
        }
    }
}
