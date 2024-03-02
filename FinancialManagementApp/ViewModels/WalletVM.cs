using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.ViewModels
{
    public class WalletVM : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private long walletNumber;
        private decimal balance;
        private string? image;

        public string BalanceView
        {
            get
            {
                return this.balance.ToString("N2") + " руб.";
            }
            set {
                OnPropertyChanged("BalanceView");
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("iId");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public long WalletNumber
        {
            get { return walletNumber; }
            set
            {
                walletNumber = value;
                OnPropertyChanged("WalletNumber");
            }
        }

        public decimal Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                BalanceView = balance.ToString();
                OnPropertyChanged("Balance");
            }
        }

        public string? Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("Image");
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
