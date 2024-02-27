using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.Repositories
{
    public class WalletHistoryRepository : BaseRepository<WalletHistory>, IWalletHistoryRepository
    {
        public WalletHistoryRepository() { }

        async public Task<bool> AddWalletHistory(WalletHistory walletHistory)
        {
            try
            {
                await _context.WalletHistories.AddAsync(walletHistory);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) { }

            return false;
        }

        public async Task<List<WalletHistory>> GetWalletHistory(int walletId)
        {
            return await _context.WalletHistories.Where(x => x.WalletId == walletId).ToListAsync();
        }
    }
}
