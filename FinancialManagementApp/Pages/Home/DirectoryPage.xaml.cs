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

            this.Loaded += async (e, s) => await InitDirectory();
        }

        async private Task InitDirectory(int? selectedCategory = null)
        {
			_directoryPageVM.ExpenseDirectoryVM = await _categoryService.GetExpenseDirectory(_homeLayoutVM.UserVM.Id, selectedCategory);

            ExpensesCategoryTable.ItemsSource = _directoryPageVM.ExpenseDirectoryVM.CategoryList;
            ExpensesSubCategoryTable.ItemsSource = _directoryPageVM.ExpenseDirectoryVM.SubCategoryList;
        }

        private async void ExpensesCategoryTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = ExpensesCategoryTable?.SelectedItem as CategoryVM;

            if(selectedCategory != null)
            {
                RemoveCategoryBtn.Visibility = Visibility.Visible;
                AddSubCategory.Visibility = Visibility.Visible;
            } 
            else
            {
				RemoveCategoryBtn.Visibility = Visibility.Hidden;
                AddSubCategory.Visibility = Visibility.Hidden;
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
            CategoryVM? selectedCategory = null;
            int selectedIndex = -1;

			if (((Button)sender).Name == "AddSubCategory")
            {
				selectedCategory = ExpensesCategoryTable?.SelectedItem as CategoryVM;
                selectedIndex = ExpensesCategoryTable.Items.IndexOf(selectedCategory);
			} 
			

			var modal = new CategoryWindow(_categoryService, _directoryPageVM, _homeLayoutVM, selectedCategory);
            modal.ShowDialog();

			ExpensesCategoryTable.ItemsSource = _directoryPageVM.ExpenseDirectoryVM.CategoryList;
            ExpensesSubCategoryTable.ItemsSource = _directoryPageVM.ExpenseDirectoryVM.SubCategoryList;

            ExpensesCategoryTable.SelectedIndex = selectedIndex == -1 ? ExpensesCategoryTable.Items.Count - 1 : selectedIndex;
		}

        async private void RemoveCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            CategoryVM? selectedCategory = ExpensesCategoryTable?.SelectedItem as CategoryVM;
            CategoryVM? selectedSubCategory = ExpensesSubCategoryTable?.SelectedItem as CategoryVM;
            
            bool isRemoveSubCategory = false;
            int selectedCategiryIndex = -1;

            if (((Button)sender).Name == "RemoveSubCategory")
            {
                isRemoveSubCategory = true;
                selectedCategiryIndex = ExpensesCategoryTable.Items.IndexOf(selectedCategory);
            }

            int categoryIdToRemove = isRemoveSubCategory ? (int)selectedSubCategory?.Id : (int)selectedCategory?.Id;

            bool status = await _categoryService.RemoveCategory(_homeLayoutVM.UserVM.Id, categoryIdToRemove);

            if (status)
            {
                await InitDirectory();
            }

            if (isRemoveSubCategory)
            {
                ExpensesCategoryTable.SelectedIndex = selectedCategiryIndex;
            }
        }

        private void ExpensesSubCategoryTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CategoryVM? selectedSubCategory = ExpensesSubCategoryTable?.SelectedItem as CategoryVM;

            if (selectedSubCategory != null)
            {
                RemoveSubCategory.Visibility = Visibility.Visible;
            }
            else
            {
                RemoveSubCategory.Visibility = Visibility.Hidden;
            }
        }
    }
}
