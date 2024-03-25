using FinancialManagementApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FinancialManagementApp.Infrastructure.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        public Task<List<Category>> GetHierarchyGategory(int categoryId);
    }
}
