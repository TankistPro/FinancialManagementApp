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
        public int OperationType { get; set;}
        [Column(TypeName = "money")]
        public decimal Value { get; set; }
        [Column(TypeName = "money")]
        public decimal NewBalance { get; set; }
        [Column(TypeName = "money")]
        public decimal OldBalance { get; set; }
        public string? Comment { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Wallet")]
        public int? WalletId { get; set; }
        public Wallet? Wallet { get; set; }
    }
}
