using FinancialManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Interfaces
{
    public interface IHomeLayoutVM
    {
        void InitVM(UserVM userVM, WalletVM walletVM);
        void OnPropertyChanged([CallerMemberName] string prop = "");
    }
}
