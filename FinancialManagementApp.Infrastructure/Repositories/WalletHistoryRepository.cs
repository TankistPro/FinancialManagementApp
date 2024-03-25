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

        async public Task<WalletHistory> AddWalletHistory(WalletHistory walletHistory)
        {
            try
            {
				await _context.WalletHistories.AddAsync(walletHistory);
                await _context.SaveChangesAsync();

                return walletHistory;
            }
            catch (Exception ex) { }

            return null;
        }

        async public Task<WalletHistory> UpdateWalletHistory(WalletHistory walletHistory)
        {
            var record = await this.GetById(walletHistory.Id);

            try
            {
               if (record != null)
                {
                    _context.WalletHistories.Entry(record).CurrentValues.SetValues(walletHistory);
                    await _context.SaveChangesAsync();
                }

                return walletHistory;
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<List<WalletHistory>> GetWalletHistory(int walletId)
        {
            return await _context.WalletHistories.Where(x => x.WalletId == walletId).OrderByDescending(x => x.CreatedDate).ToListAsync();
        }
    }
}
