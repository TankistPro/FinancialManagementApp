using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.ModelDto;
using System;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.Interfaces
{
    public interface IWalletRepository : IBaseRepository<Wallet>
    {
        Task<int> CreateWallet(WalletDto wallet);
        Task<Wallet> GetUserWallet(int userId);
        Task<decimal?> CreateWalletOperation(WalletHistoryDto walletHistoryDto);
        Task<bool> AddWalletHistory(WalletHistoryDto walletHistoryDto);
    }
}
