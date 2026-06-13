using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid Id);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

        IQueryable<T> Query();
    }
}
