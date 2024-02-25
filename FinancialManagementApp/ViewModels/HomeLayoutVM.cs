using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinancialManagementApp.ViewModels
{
    public class HomeLayoutVM : IHomeLayoutVM, INotifyPropertyChanged
    {
        private UserVM _userVM;
        private WalletVM _walletVM;

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


        public void InitVM(UserVM userVM, WalletVM walletVM)
        {
            this.UserVM = userVM;
            this.WalletVM = walletVM;
        }
        

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
