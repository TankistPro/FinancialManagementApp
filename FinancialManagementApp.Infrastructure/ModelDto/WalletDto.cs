using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.ModelDto
{
    public class WalletDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long WalletNumber { get; set; }
        public decimal Balance { get; set; }
        public string? Image { get; set; }

        public int UserId { get; set; }
    }
}
