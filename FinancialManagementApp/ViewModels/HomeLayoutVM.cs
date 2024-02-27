using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinancialManagementApp.ViewModels
{
    public class HomeLayoutVM : IHomeLayoutVM, INotifyPropertyChanged
    {
        private UserVM _userVM;
        private WalletVM _walletVM;
        private ObservableCollection<WalletHistoryVM> _listWalletHistoryVM;

        public UserVM UserVM
        {
            get { return _userVM; }
            set
            {
                _userVM = value;
                OnPropertyChanged("UserVM");
            }
        }

        public WalletVM WalletVM
        {
            get { return _walletVM; }
            set
            {
                _walletVM = value;
                OnPropertyChanged("WalletVM");
            }
        }

        public ObservableCollection<WalletHistoryVM> ListWalletHistoryVM
        {
            get { return _listWalletHistoryVM; }
            set
            {
                _listWalletHistoryVM = value;
                OnPropertyChanged("ListWalletHistoryVM");
            }
        }


        public void InitVM(UserVM userVM, WalletVM walletVM, ObservableCollection<WalletHistoryVM>? listWalletHistoryVM)
        {
            this.UserVM = userVM;
            this.WalletVM = walletVM;

            if(listWalletHistoryVM != null)
            {
                this._listWalletHistoryVM = listWalletHistoryVM;
            }
        }

        public void InsertWalletHistoryRecord(WalletHistoryVM walletHistoryVM)
        {
            this.ListWalletHistoryVM.Insert(0, walletHistoryVM);
        }
        

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
