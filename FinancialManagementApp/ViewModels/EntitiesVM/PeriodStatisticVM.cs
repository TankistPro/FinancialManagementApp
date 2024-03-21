using FinancialManagementApp.Infrastructure.ModelDto;
using SharpVectors.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.ViewModels
{
    public class PeriodStatisticVM : INotifyPropertyChanged
	{
        private DateTime? _startDate {  get; set; }
		private DateTime? _endDate { get; set; }
		private decimal _incomePeriod { get; set; }
		private decimal _expensesPeriod { get; set; }
		private decimal _otherPeriond { get; set; }

		public string DateTimePeriodView
		{
			get
			{
				if (EndDate == null)
				{
					return $"Статистика за {StartDate?.ToString("d")}г.";
				} 
				return $"Статистика c {StartDate?.ToString("d")}г. по {EndDate?.ToString("d")}г.";
			}
			set
			{
				OnPropertyChanged("DateTimePeriodView");
			}
		}

		public decimal IncomePeriod
		{
			get { return _incomePeriod; }
			set
			{
				_incomePeriod = value;
				OnPropertyChanged("IncomePeriod");
			}
		}

		public decimal ExpensesPeriod
		{
			get { return _expensesPeriod; }
			set
			{
				_expensesPeriod = value;
				OnPropertyChanged("ExpensesPeriod");
			}
		}

		public decimal OtherPeriond
		{
			get { return _otherPeriond; }
			set
			{
				_otherPeriond = value;
				OnPropertyChanged("OtherPeriond");
			}
		}

		public DateTime? StartDate
		{
			get { return _startDate; }
			set
			{
				_startDate = value;
				DateTimePeriodView = value.ToString();
				OnPropertyChanged("StartDate");
			}
		}

		public DateTime? EndDate
		{
			get { return _endDate; }
			set
			{
				_endDate = value;
				DateTimePeriodView = value.ToString();
				OnPropertyChanged("EndDate");
			}
		}

		public void InitStatistic(PeriodStatisticDto periodStatisticDto)
		{
			StartDate = periodStatisticDto.StartDate;
			EndDate = periodStatisticDto.EndDate;
			IncomePeriod = periodStatisticDto.IncomePeriod;
			ExpensesPeriod = periodStatisticDto.ExpensesPeriod;
			OtherPeriond = periodStatisticDto.OtherPeriond;
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}
