using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.ViewModels
{
    public class RegistrationPageVM : BaseViewModel
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
    }
}
