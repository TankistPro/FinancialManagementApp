using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.ModelDto;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<int> RegistartionUser(RegistrationUserDto user);
        Task<User> LoginUser(string email, string password);
    }
}
