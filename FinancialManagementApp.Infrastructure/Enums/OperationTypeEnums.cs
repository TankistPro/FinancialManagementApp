using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.Enums
{
    public static class WalletOperations
    {
        public enum OperationTypeEnums
        {
            Income = 0,
            Expenses = 1,
            Other = 2
        }

        public static Dictionary<int, string> walletOperationsDict = new Dictionary<int, string>()
        {
            {0, "Доход" },
            {1, "Расход" },
            {2, "Другое" },
        };
    }
}
