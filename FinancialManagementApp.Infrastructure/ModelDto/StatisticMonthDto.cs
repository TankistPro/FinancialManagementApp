using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.ModelDto
{
    public class StatisticMonthDto
    {
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Other { get; set; }
    }
}
