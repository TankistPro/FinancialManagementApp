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
        private readonly IWalletHistoryRepository _walletHistoryRepository;
        public WalletRepository() 
        {
            _walletHistoryRepository = new WalletHistoryRepository();
        }
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

        /// <summary>
        /// Создание операции по кошельку
        /// </summary>
        /// <param name="walletHistoryDto"></param>
        /// <returns>Возвращается новый баланс пользователя</returns>
        async public Task<WalletHistory?> CreateWalletOperation(WalletHistory walletHistory)
        {
            var userWallet = await _context.Wallets.Where(x => x.Id == walletHistory.WalletId).FirstOrDefaultAsync();

            if (userWallet != null) 
            {
                try
                {
                    walletHistory.OldBalance = userWallet.Balance;
                    userWallet.Balance += walletHistory.Value;
                    walletHistory.NewBalance = userWallet.Balance;

                    await _context.SaveChangesAsync();

                    WalletHistory record = await _walletHistoryRepository.AddWalletHistory(walletHistory);

                    if (record != null)
                    {
                        return record;
                    }
                } catch (Exception ex) { }
            }
            
            return null;
        }

        async public Task<WalletHistory?> UpdateWalletOperation(WalletHistory walletHistory)
        {
            var userWallet = await _context.Wallets.Where(x => x.Id == walletHistory.WalletId).FirstOrDefaultAsync();

            if (userWallet != null) 
            {
                var oldValue = await _context.WalletHistories.Where(x => x.Id == walletHistory.Id).Select(x => x.Value).FirstOrDefaultAsync();

                try
                {
                    walletHistory.OldBalance = userWallet.Balance;
                    userWallet.Balance += walletHistory.Value - oldValue;
                    walletHistory.NewBalance = userWallet.Balance;

                    await _context.SaveChangesAsync();

                    WalletHistory record = await _walletHistoryRepository.UpdateWalletHistory(walletHistory);

                    if (record != null)
                    {
                        return record;
                    }
                } catch (Exception ex) { }
            }

            return null;
        }
    }
}
