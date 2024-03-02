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
using static FinancialManagementApp.Infrastructure.Enums.WalletOperations;

namespace FinancialManagementApp.Services
{
    public class StatisticService
    {
        private readonly WalletHistoryRepository _walletRepository;

        public StatisticService() 
        {
            _walletRepository = new WalletHistoryRepository();
        }

        async public Task<StatisticMonthDto> InitStatiscticByMonth(int month, int year, int walletId)
        {
            List<WalletHistory> AllHistory = await _walletRepository.GetAll();

            List<WalletHistory> filterdHistory = AllHistory
                .Where(x => x.CreatedDate.Month == month && x.CreatedDate.Year == year && x.WalletId == walletId).ToList();

            var income = filterdHistory.Where(x => x.OperationType == (int)OperationTypeEnums.Income).Sum(x => x.Value);
            var expenses = filterdHistory.Where(x => x.OperationType == (int)OperationTypeEnums.Expenses).Sum(x => x.Value);
            var other = filterdHistory.Where(x => x.OperationType == (int)OperationTypeEnums.Other).Sum(x => x.Value);

            return new StatisticMonthDto()
            {
                Income = income,
                Expenses = expenses,
                Other = other
            };
        }
    }
}
