using FinancialManagementApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.Interfaces
{
    public interface IWalletHistoryRepository
    {
        Task<List<WalletHistory>> GetWalletHistory(int walletId);
        Task<WalletHistory> AddWalletHistory(WalletHistory walletHistoryDto);
        Task<WalletHistory> UpdateWalletHistory(WalletHistory walletHistory);
    }
}
