using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.ViewModels
{
    public class WalletHistoryVM
    {
        private int walletId;
        private string operationType;
        private decimal walletValue;
        private decimal newBalance;
        private decimal oldBalance;
        private string? comment;
        private int status;
        private DateTime createdDate;

        public int WalletId
        {
            get { return walletId; }
            set
            {
                walletId = value;
                OnPropertyChanged("WalletId");
            }
        }

        public decimal WalletValue
        {
            get { return walletValue; } 
            set 
            {
                walletValue = value;
                OnPropertyChanged("WalletValue");
            }
        }

        public decimal NewBalance
        {
            get { return newBalance; }
            set
            {
                newBalance = value;
                OnPropertyChanged("NewBalance");
            }
        }

        public decimal OldBalance
        {
            get { return oldBalance; }
            set
            {
                oldBalance = value;
                OnPropertyChanged("OldBalance");
            }
        }

        public string OperationType
        {
            get { return operationType; }
            set
            {
                operationType = value;
                OnPropertyChanged("OperationType");
            }
        }

        public string? Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                OnPropertyChanged("Comment");
            }
        }

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set
            {
                createdDate = value;
                OnPropertyChanged("CreatedDate");
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
