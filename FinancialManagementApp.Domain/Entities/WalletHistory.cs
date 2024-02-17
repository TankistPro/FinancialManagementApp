using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Domain.Entities
{
    public class WalletHistory
    {
        public int Id { get; set; }
        public string OperationType { get; set;}
        public decimal Value { get; set; }
        public decimal NewBalance { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
