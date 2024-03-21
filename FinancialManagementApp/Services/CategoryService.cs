using AutoMapper;
using FinancialManagementApp.Infrastructure.Enums;
using FinancialManagementApp.Infrastructure.Repositories;
using FinancialManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
