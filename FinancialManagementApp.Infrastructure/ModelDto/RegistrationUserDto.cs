using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.ModelDto
{
    public class RegistrationUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public int EmailConfirmed { get; set; }
        public string Password { get; set; }
        public long WalletNumber { get; set; }
        public decimal Balance { get; set; }
        public string? AvatarHash { get; set; }
        public int WalletId { get; set; }
    }
}
