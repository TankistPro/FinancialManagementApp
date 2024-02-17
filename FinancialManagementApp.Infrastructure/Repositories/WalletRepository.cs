using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.Interfaces;
using FinancialManagementApp.Infrastructure.ModelDto;
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
            };

            bool status = await this.AddAsync(newWallet);

            if (status)
            {
                return newWallet.Id;
            }

            return -1;
        }
    }
}
