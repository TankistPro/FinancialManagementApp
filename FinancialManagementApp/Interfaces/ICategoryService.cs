using FinancialManagementApp.ViewModels;
using FinancialManagementApp.ViewModels.EntitiesVM.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Interfaces
{
	public interface ICategoryService
	{
		public Task<ExpenseDirectoryVM> GetExpenseDirectory(int userId, int? categoryId);
		public Task<List<CategoryVM>> GetExpensesCategory(int userID);
		public Task<List<CategoryVM>> GetSubCategories(int userID, int categoryId);
		public Task<CategoryVM>? SaveNewCategory(CategoryVM categoryVM);
		public Task<bool> RemoveCategory(int userID, int categoryID);
	}
}
