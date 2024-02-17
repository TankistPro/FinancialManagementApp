using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Domain.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WalletNumber { get; set; }
        public decimal Balance { get; set; }
        public string? Image { get; set; }

        public User User { get; set; }
        public WalletHistory? WalletHistory { get; set; }
    }
}
