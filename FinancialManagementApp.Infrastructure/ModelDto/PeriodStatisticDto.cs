using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.ModelDto
{
	public class PeriodStatisticDto
	{
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public decimal IncomePeriod { get; set; }
		public decimal ExpensesPeriod { get; set; }
		public decimal OtherPeriond { get; set; }
	}
}
