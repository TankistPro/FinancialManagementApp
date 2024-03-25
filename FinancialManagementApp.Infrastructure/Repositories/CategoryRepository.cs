using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        /// <summary>
        ///    Получение всех элементов (иерархии) выбранной категории
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        async public Task<List<Category>> GetHierarchyGategory(int categoryId)
        {
            Category category = await GetById(categoryId);

            if (category == null)
            {
                return new List<Category>() { category };
            }

            return await _context.Categories.Where(x => x.Id == categoryId || x.ParentId == categoryId).ToListAsync();
        }
    }
}
