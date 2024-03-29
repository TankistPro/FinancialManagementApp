﻿using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.ModelDto;
using System;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.Interfaces
{
    public interface IWalletRepository : IBaseRepository<Wallet>
    {
        Task<int> CreateWallet(WalletDto wallet);
        Task<Wallet> GetUserWallet(int userId);
        Task<WalletHistory?> CreateWalletOperation(WalletHistory walletHistoryDto);
        Task<WalletHistory?> UpdateWalletOperation(WalletHistory walletHistory);
	}
}
