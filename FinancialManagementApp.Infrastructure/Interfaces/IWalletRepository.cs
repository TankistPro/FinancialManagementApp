using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.ModelDto;
using System;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.Interfaces
{
    public interface IWalletRepository : IBaseRepository<Wallet>
    {
        Task<int> CreateWallet(WalletDto wallet);
    }
}
