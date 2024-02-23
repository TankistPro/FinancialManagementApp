using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.ModelDto
{
    public class WalletHistoryDto
    {
        public int Id { get; set; }
        public int WalletId { get; set; }
        public string OperationType { get; set; }
        public decimal Value { get; set; }
        public decimal NewBalance { get; set; }
        public decimal OldBalance { get; set; }
        public string? Comment { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
