using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialManagementApp.Domain.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long WalletNumber { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Balance { get; set; }
        public string? Image { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
