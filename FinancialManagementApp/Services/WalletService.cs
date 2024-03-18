using AutoMapper;
using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.Infrastructure.Repositories;
using FinancialManagementApp.Interfaces;
using FinancialManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Services
{
    public class WalletService : IWalletService
    {
        private readonly WalletRepository _walletRepository;
        private readonly WalletHistoryRepository _walletHistoryRepository;
        private readonly IMapper _mapper;
        public WalletService(IMapper mapper) 
        {
            _mapper = mapper;
            _walletRepository = new WalletRepository();
            _walletHistoryRepository = new WalletHistoryRepository();
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

        async public Task<WalletVM> GetUserWallet(int userId)
        {
            Wallet walletEntity = await _walletRepository.GetUserWallet(userId);

            return _mapper.Map<WalletVM>(walletEntity);
        }

        async public Task<WalletHistoryVM?> CreateWalletOperation(WalletHistoryVM walletHistory)
        {
            WalletHistory walletEntity = _mapper.Map<WalletHistory>(walletHistory);
            // TODO: FIX Mapper ?????
            walletEntity.Value = walletHistory.WalletValue;

            WalletHistory? record = await _walletRepository.CreateWalletOperation(walletEntity);

            if (record != null) 
            {
                return _mapper.Map<WalletHistoryVM>(record);
            }

            return null;
        }

        async public Task<WalletHistoryVM?> UpdateWalletOperation(WalletHistoryVM walletHistory)
        {
            WalletHistory walletEntity = _mapper.Map<WalletHistory>(walletHistory);
            // TODO: FIX Mapper ?????
            walletEntity.Value = walletHistory.WalletValue;

            WalletHistory? record = await _walletRepository.UpdateWalletOperation(walletEntity);

            if (record != null)
            {
                return _mapper.Map<WalletHistoryVM>(record);
            }

            return null;
        }

        async public Task<List<WalletHistoryVM>> GetWalletHistory(int walletId)
        {
            List<WalletHistory> history = await _walletHistoryRepository.GetWalletHistory(walletId);

            return _mapper.Map<List<WalletHistoryVM>>(history);
        }
    }
}
