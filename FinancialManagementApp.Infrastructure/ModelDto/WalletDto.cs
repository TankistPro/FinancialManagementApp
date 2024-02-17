using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.ModelDto
{
    public class WalletDto
    {
        public string Name { get; set; }
        public int WalletNumber { get; set; }
        public decimal Balance { get; set; }
        public string? Image { get; set; }
    }
}
