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

        /// <summary>
        /// Создание операции по кошельку
        /// </summary>
        /// <param name="walletHistoryDto"></param>
        /// <returns>Возвращается новый баланс пользователя</returns>
        async public Task<decimal?> CreateWalletOperation(WalletHistoryDto walletHistoryDto)
        {
            var userWallet = await _context.Wallets.Where(x => x.Id == walletHistoryDto.WalletId).FirstOrDefaultAsync();

            if (userWallet != null) 
            {
                try
                {
                    walletHistoryDto.OldBalance = userWallet.Balance;
                    userWallet.Balance += walletHistoryDto.Value;
                    walletHistoryDto.NewBalance = userWallet.Balance;

                    await _context.SaveChangesAsync();

                    bool status = await this.AddWalletHistory(walletHistoryDto);

                    if (status)
                    {
                        return userWallet.Balance;
                    }
                } catch (Exception ex) { }
            }
            
            return null;
        }


        async public Task<bool> AddWalletHistory(WalletHistoryDto walletHistoryDto)
        {
            var newHistory = new WalletHistory()
            {
                OperationType = "Доход",
                Value = walletHistoryDto.Value,
                NewBalance = walletHistoryDto.NewBalance,
                OldBalance = walletHistoryDto.OldBalance,
                Comment = walletHistoryDto.Comment,
                Status = walletHistoryDto.Status,
                CreatedDate = DateTime.Now,
                WalletId = walletHistoryDto.WalletId,
            };

            try
            {
                await _context.WalletHistories.AddAsync(newHistory);
                await _context.SaveChangesAsync();

                return true;
            } catch (Exception ex) { }

            return false;
        }
    }
}
