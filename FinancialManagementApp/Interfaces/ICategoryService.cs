using FinancialManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.Interfaces
{
	public interface ICategoryService
	{
		public Task<List<CategoryVM>> GetExpensesCategory(int userID);
		public Task<List<CategoryVM>> GetSubCategories(int userID, int categoryId);
		public Task<CategoryVM>? SaveNewCategory(CategoryVM categoryVM);
	}
}
