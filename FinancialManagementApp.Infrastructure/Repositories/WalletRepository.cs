using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.Interfaces;
using FinancialManagementApp.Infrastructure.ModelDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.Repositories
{
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        async public Task<int> CreateWallet(WalletDto wallet)
        {
            var newWallet = new Wallet()
            {
                Name = wallet.Name,
                WalletNumber = wallet.WalletNumber,
                Balance = wallet.Balance,
                Image = wallet.Image ?? String.Empty,
                UserId = wallet.UserId,
            };

            bool status = await this.AddAsync(newWallet);

            if (status)
            {
                return newWallet.Id;
            }

            return -1;
        }

        async public Task<Wallet> GetUserWallet(int userId)
        {
            var wallet= await _context.Wallets.Where(x => x.UserId == userId).FirstOrDefaultAsync();

            return wallet;
        }
    }
}
