using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.ViewModels
{
    public class StatisticMonthVM : INotifyPropertyChanged
    {
        private decimal income { get; set; }
        private decimal expenses { get; set; }
        private decimal other { get; set; }


        public decimal Income
        {
            get { return income; }
            set
            {
                income = value;
                OnPropertyChanged("Income");
            }
        }

        public decimal Expenses
        {
            get { return expenses; }
            set
            {
                expenses = value;
                OnPropertyChanged("Expenses");
            }
        }

        public decimal Other
        {
            get { return other; }
            set
            {
                other = value;
                OnPropertyChanged("Other");
            }
        }

        public void InitStatistic(StatisticMonthDto statisticMonthDto)
        {
            this.Other = statisticMonthDto.Other;
            this.Expenses = statisticMonthDto.Expenses;
            this.Income = statisticMonthDto.Income;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
