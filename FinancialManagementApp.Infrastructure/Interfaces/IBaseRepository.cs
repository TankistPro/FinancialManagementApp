using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialManagementApp.Infrastructure.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRageAsync(List<T> entities);
        bool Remove(T entity);
        bool RemoveRange(List<T> entities);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}
