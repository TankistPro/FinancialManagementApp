using FinancialManagementApp.Infrastructure.Enums;
using FinancialManagementApp.Interfaces;
using FinancialManagementApp.Services;
using FinancialManagementApp.ViewModels;
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
        private CategoryService _categoryService;
        public DirectoryPage(
            DirectoryPageVM directoryPageVM,
            HomeLayoutVM homeLayoutVM,
            CategoryService categoryService
            )
        {
            InitializeComponent();

            _directoryPageVM = directoryPageVM;
            _homeLayoutVM = homeLayoutVM;
            _categoryService = categoryService;

            this.DataContext = _directoryPageVM;

            this.Loaded += (e, s) => InitDirectory();
        }

        async private void InitDirectory()
        {
            var list = await _categoryService.GetExpensesCategory(_homeLayoutVM.UserVM.Id);

            _directoryPageVM.SetCategoryListVM(new ObservableCollection<CategoryVM>(list));

            ExpensesCategoryTable.ItemsSource = _directoryPageVM.CategoryListVM?.Where(x => x.ParentId == null && x.DirectoryType != null && x.DirectoryType == DirectoryCategoriesType.Expenses);
        }

        private async void ExpensesCategoryTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = ExpensesCategoryTable?.SelectedItem as CategoryVM;

            if(selectedCategory != null )
            {
                EditCategoryBtn.Visibility = Visibility.Visible;
                RemoveCategoryBtn.Visibility = Visibility.Visible;
            }

            if(selectedCategory?.ParentId == null) 
            {
                var subList = await _categoryService.GetSubCategories(_homeLayoutVM.UserVM.Id, (int)selectedCategory?.Id);

                ExpensesSubCategoryTable.ItemsSource = subList;
            }
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            var modal = new CategoryWindow(_categoryService, _directoryPageVM, _homeLayoutVM);
            modal.ShowDialog();
        }
    }
}
