using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Domain.Entities
{
    public class WalletHistory
    {
        public int Id { get; set; }
        public string OperationType { get; set;}
        [Column(TypeName = "decimal(18,4)")]
        public decimal Value { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal NewBalance { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal OldBalance { get; set; }
        public string? Comment { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public Wallet? Wallet { get; set; }
    }
}
