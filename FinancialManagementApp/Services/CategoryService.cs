using AutoMapper;
using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.Enums;
using FinancialManagementApp.Infrastructure.Repositories;
using FinancialManagementApp.Interfaces;
using FinancialManagementApp.ViewModels;
using FinancialManagementApp.ViewModels.EntitiesVM.Directory;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.ObjectModel;

namespace FinancialManagementApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper) 
        {
            _categoryRepository = new CategoryRepository();
            _mapper = mapper;
        }

		async public Task<ExpenseDirectoryVM> GetExpenseDirectory(int userId, int? categoryId)
		{
			var allRecords = await _categoryRepository.GetAll();

            var list = allRecords.Where(x => x.UserId == userId).ToList();

            List<CategoryVM> categoryList = await GetExpensesCategory(userId);
			List<CategoryVM>? subList = null;

			if (categoryId != null)
            {
                subList = await GetSubCategories(userId, (int)categoryId);
			}

            return new ExpenseDirectoryVM
            {
                CategoryList = new ObservableCollection<CategoryVM>(categoryList),
                SubCategoryList = subList != null ? new ObservableCollection<CategoryVM>(subList) : null
            };
		}

		async public Task<List<CategoryVM>> GetExpensesCategory(int userID)
        {
            var list = await _categoryRepository.GetAll();

            list = list.Where(x => x.UserId == userID && x.DirectoryType == DirectoryCategoriesType.Expenses).ToList();

            return _mapper.Map<List<CategoryVM>>(list);
        }

        async public Task<List<CategoryVM>> GetSubCategories(int userID, int categoryId) 
        {
            var list = await _categoryRepository.GetAll();

            list = list.Where(x => x.UserId == userID && x.ParentId == categoryId).ToList();

            return _mapper.Map<List<CategoryVM>>(list);
        }

        public async Task<bool> RemoveCategory(int userID, int categoryID)
        {
            List <Category> hierarchy = await _categoryRepository.GetHierarchyGategory(categoryID);
            bool status = false;
            if(hierarchy.Count == 1)
            {
                status = _categoryRepository.Remove(hierarchy.Where(x => x.Id == categoryID).FirstOrDefault());
            } 
            else if (hierarchy.Count > 1)
            {
                bool isSuccess = _categoryRepository.RemoveRange(hierarchy.Where(x => x.ParentId == categoryID).ToList());

                if (isSuccess)
                {
                    status = _categoryRepository.Remove(hierarchy.Where(x => x.Id == categoryID).FirstOrDefault());
                }
            }

            return status;
        }

        async public Task<CategoryVM>? SaveNewCategory(CategoryVM categoryVM)
        {
            try
            {
				var entity = _mapper.Map<Category>(categoryVM);

                await _categoryRepository.AddAsync(entity);

                return _mapper.Map<CategoryVM>(entity);
			} catch (Exception ex)
            {
                return null;
            }	
		}
    }
}
