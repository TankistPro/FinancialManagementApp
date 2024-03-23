using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.ViewModels.EntitiesVM.Directory
{
	public class ExpenseDirectoryVM : BaseViewModel
	{
		private ObservableCollection<CategoryVM> _categoryList;
		private ObservableCollection<CategoryVM>? _subCategoryList;

		public ObservableCollection<CategoryVM> CategoryList
		{
			get { return _categoryList; }
			set { 
				_categoryList = value;
				OnPropertyChanged("CategoryList");
			}
		}

		public ObservableCollection<CategoryVM>? SubCategoryList
		{
			get { return _subCategoryList; }
			set
			{
				_subCategoryList = value;
				OnPropertyChanged("SubCategoryList");
			}
		}
	}
}
