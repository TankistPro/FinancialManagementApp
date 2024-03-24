using FinancialManagementApp.Infrastructure.Enums;
using FinancialManagementApp.Interfaces;
using FinancialManagementApp.Services;
using FinancialManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FinancialManagementApp.Window
{
	/// <summary>
	/// Логика взаимодействия для CategoryWindow.xaml
	/// </summary>
	public partial class CategoryWindow : System.Windows.Window
	{
		private CategoryVM _categoryVM;
		private ICategoryService _categoryService;
		private DirectoryPageVM _directoryPageVM;
		private HomeLayoutVM _homeLayoutVM;
		public CategoryWindow(ICategoryService categoryService, DirectoryPageVM directoryPageVM, HomeLayoutVM homeLayoutVM, CategoryVM? category)
		{
			InitializeComponent();

			_categoryService = categoryService;
			_directoryPageVM = directoryPageVM;
			_homeLayoutVM = homeLayoutVM;
			_categoryVM = new CategoryVM()
			{
				Order = 1,
				DirectoryType = category == null ? DirectoryCategoriesType.Expenses : String.Empty,
				UserId = _homeLayoutVM.UserVM.Id,
				ParentId = category?.Id
			};
			this.DataContext = _categoryVM;
		}

		private void cp_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
		{
			if(cp.SelectedColor.HasValue)
			{}
		}

		async private void SaveCategory_Click(object sender, RoutedEventArgs e)
		{
			CategoryVM? category = await _categoryService.SaveNewCategory(_categoryVM);

			if (category != null)
			{
				_directoryPageVM.ExpenseDirectoryVM = await _categoryService.GetExpenseDirectory(_homeLayoutVM.UserVM.Id, category.Id);

				this.Hide();
			}
		}
	}
}
