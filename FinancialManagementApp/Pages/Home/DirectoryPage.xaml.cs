using FinancialManagementApp.Infrastructure.Enums;
using FinancialManagementApp.Interfaces;
using FinancialManagementApp.Services;
using FinancialManagementApp.ViewModels;
using FinancialManagementApp.ViewModels.EntitiesVM.Directory;
using FinancialManagementApp.Window;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinancialManagementApp.Pages.Home
{
    /// <summary>
    /// Логика взаимодействия для DirectoryPage.xaml
    /// </summary>
    public partial class DirectoryPage : Page
    {
        private DirectoryPageVM _directoryPageVM;
        private HomeLayoutVM _homeLayoutVM;
        private ICategoryService _categoryService;
        public DirectoryPage(
            DirectoryPageVM directoryPageVM,
            HomeLayoutVM homeLayoutVM,
			ICategoryService categoryService
            )
        {
            InitializeComponent();

            _directoryPageVM = directoryPageVM;
            _homeLayoutVM = homeLayoutVM;
            _categoryService = categoryService;

            this.Loaded += (e, s) => InitDirectory();
        }

        async private void InitDirectory()
        {
            var list = await _categoryService.GetExpensesCategory(_homeLayoutVM.UserVM.Id);

            var catalogList = list.Where(x => x.ParentId == null && x.DirectoryType != null && x.DirectoryType == DirectoryCategoriesType.Expenses).ToList();

            _directoryPageVM.ExpenseDirectoryVM.CategoryList = new ObservableCollection<CategoryVM>(catalogList);

            ExpensesCategoryTable.ItemsSource = _directoryPageVM.ExpenseDirectoryVM.CategoryList;
            ExpensesCategoryTable.SelectedIndex = 0;

		}

        private async void ExpensesCategoryTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = ExpensesCategoryTable?.SelectedItem as CategoryVM;

            if(selectedCategory != null)
            {
                EditCategoryBtn.Visibility = Visibility.Visible;
                RemoveCategoryBtn.Visibility = Visibility.Visible;
            } 
            else
            {
				EditCategoryBtn.Visibility = Visibility.Hidden;
				RemoveCategoryBtn.Visibility = Visibility.Hidden;
			}

            if(selectedCategory != null && selectedCategory?.ParentId == null) 
            {
                var subList = await _categoryService.GetSubCategories(_homeLayoutVM.UserVM.Id, (int)selectedCategory?.Id);

                _directoryPageVM.ExpenseDirectoryVM.SubCategoryList = new ObservableCollection<CategoryVM>(subList);

				ExpensesSubCategoryTable.ItemsSource = subList;
            }
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            var modal = new CategoryWindow(_categoryService, _directoryPageVM, _homeLayoutVM);
            modal.ShowDialog();

			ExpensesCategoryTable.ItemsSource = _directoryPageVM.ExpenseDirectoryVM.CategoryList;
		}
    }
}
