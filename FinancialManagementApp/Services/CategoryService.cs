using AutoMapper;
using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.Enums;
using FinancialManagementApp.Infrastructure.Repositories;
using FinancialManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace FinancialManagementApp.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper) 
        {
            _categoryRepository = new CategoryRepository();
            _mapper = mapper;
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
