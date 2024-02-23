using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.ModelDto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string? AvatarHash { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
