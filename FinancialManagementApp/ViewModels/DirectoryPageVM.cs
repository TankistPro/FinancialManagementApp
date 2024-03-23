using FinancialManagementApp.ViewModels.EntitiesVM.Directory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.ViewModels
{
    public class DirectoryPageVM : BaseViewModel
    {
        private ExpenseDirectoryVM _expenseDirectoryVM = new ExpenseDirectoryVM();

		public ExpenseDirectoryVM ExpenseDirectoryVM
        {
            get { return _expenseDirectoryVM; }
            set { 
                _expenseDirectoryVM = value;
                OnPropertyChanged("ExpenseDirectoryVM");
            }
        }
    }
}
