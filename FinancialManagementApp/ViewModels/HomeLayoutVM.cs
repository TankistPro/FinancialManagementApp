using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.ViewModels
{
    public class HomeLayoutVM : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
