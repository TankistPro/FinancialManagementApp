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
            Wallet userWallet = await getUserWalletById((int)walletHistory.WalletId);

            if (userWallet != null) 
            {
                try
                {
                    decimal oldBalance = userWallet.Balance;
                    decimal updatetdBalance = await updateUserBalance(userWallet.Balance + walletHistory.Value, userWallet.UserId);

					await _context.SaveChangesAsync();

					walletHistory.OldBalance = oldBalance;
					walletHistory.NewBalance = updatetdBalance;

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
			Wallet userWallet = await getUserWalletById((int)walletHistory.WalletId);

			if (userWallet != null) 
            {
                var oldHistory = await _context.WalletHistories.Where(x => x.Id == walletHistory.Id).FirstOrDefaultAsync();

                try
                {
					decimal oldBalance = userWallet.Balance;
					decimal newBalanceToUpdate = userWallet.Balance + (walletHistory.Value - oldHistory.Value);
					decimal updatetdBalance = await updateUserBalance(newBalanceToUpdate, userWallet.UserId);

					walletHistory.OldBalance = oldBalance;
					walletHistory.NewBalance = updatetdBalance;

					WalletHistory record = await _walletHistoryRepository.UpdateWalletHistory(walletHistory);

                    if (record != null)
                    {
                        return record;
                    }
                } catch (Exception ex) { }
            }

            return null;
        }

        async private Task<Wallet?> getUserWalletById(int walletId)
        {
			return await _context.Wallets.Where(x => x.Id == walletId).FirstOrDefaultAsync();
		}

        async private Task<decimal> updateUserBalance(decimal newBalance, int userId)
        {
            Wallet userWallet = await GetUserWallet(userId);

            if (userWallet != null)
            {
				userWallet.Balance = newBalance;
				await _context.SaveChangesAsync();

			}

			await _context.SaveChangesAsync();

            return userWallet.Balance;
		}
    }
}
