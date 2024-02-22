using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Services
{
    public class WalletService
    {
        private readonly WalletRepository _walletRepository;
        public WalletService() 
        {
            _walletRepository = new WalletRepository();
        }

        /// <summary>
        /// Создание кошелька пользователя
        /// </summary>
        /// <param name="walletDto"></param>
        /// <returns>Id нового кошелька</returns>
        async public Task<int> CreateWallet(WalletDto walletDto)
        {
            try
            {
                var userWallet = new WalletDto()
                {
                    Name = "Test",
                    WalletNumber = walletDto.WalletNumber,
                    Balance = walletDto.Balance,
                    UserId = walletDto.UserId,
                };

                int walletId = await _walletRepository.CreateWallet(walletDto);

                return walletId;
            }
            catch (Exception) {}
            
            return -1;
        }
    }
}
