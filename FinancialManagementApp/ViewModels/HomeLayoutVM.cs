using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.ModelDto;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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


        public void InitVM(UserDto userDto, WalletDto walletDto)
        {
            var userVM = new UserVM()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                MiddleName = userDto.MiddleName,
            };

            var walletVm = new WalletVM()
            {
                Id = walletDto.Id,
                Name = walletDto.Name,
                Balance = walletDto.Balance,
                WalletNumber = walletDto.WalletNumber,
            };

            this.UserVM = userVM;
            this.WalletVM = walletVm;
        }
        

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
