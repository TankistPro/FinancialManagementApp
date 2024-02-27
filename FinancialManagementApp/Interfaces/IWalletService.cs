using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Interfaces
{
    public interface IWalletService
    {
        Task<int> CreateWallet(WalletDto walletDto);
        Task<WalletVM> GetUserWallet(int userId);
        Task<decimal?> CreateWalletOperation(WalletHistoryVM walletHistoryDto);
        Task<List<WalletHistoryVM>> GetWalletHistory(int walletId);
    }
}
