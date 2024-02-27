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
        private HomeLayoutVM _homeLayoutVM;
        public HistoryPage(HomeLayoutVM homeLayoutVM, IWalletService walletService)
        {
            InitializeComponent();

            _walletService = walletService;
            _homeLayoutVM = homeLayoutVM;

            this.Loaded += (e, s) => InitHistory();
        }

        async private void InitHistory()
        {
            var history = await _walletService.GetWalletHistory(_homeLayoutVM.WalletVM.Id);

            _homeLayoutVM.ListWalletHistoryVM = new ObservableCollection<WalletHistoryVM>(history.AsEnumerable());

            WalletHistoryTable.ItemsSource = _homeLayoutVM.ListWalletHistoryVM;
        }
    }
}
