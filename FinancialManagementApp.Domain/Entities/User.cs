using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int EmailConfirmed { get; set; }
        public string? AvatarHash { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Wallet Wallet { get; set; }
    }
}
