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
		private CategoryService _categoryService;
		private DirectoryPageVM _directoryPageVM;
		private HomeLayoutVM _homeLayoutVM;
		public CategoryWindow(CategoryService categoryService, DirectoryPageVM directoryPageVM, HomeLayoutVM homeLayoutVM)
		{
			InitializeComponent();

			_categoryService = categoryService;
			_directoryPageVM = directoryPageVM;
			_homeLayoutVM = homeLayoutVM;
			_categoryVM = new CategoryVM()
			{
				Order = 1,
				DirectoryType = DirectoryCategoriesType.Expenses,
				UserId = _homeLayoutVM.UserVM.Id
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
				var list = await _categoryService.GetExpensesCategory(_homeLayoutVM.UserVM.Id);

				_directoryPageVM.SetCategoryListVM(new ObservableCollection<CategoryVM>(list));

				this.Hide();
			}
		}
	}
}
