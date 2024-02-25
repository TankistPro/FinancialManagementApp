using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.ViewModels;

namespace FinancialManagementApp.Interfaces
{
    public interface IAuthService
    {
        Task<int> RegistartionUser(RegistrationUserDto user);
        Task<UserVM> LoginUser(string email, string password);
    }
}
