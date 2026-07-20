using BirlesikERP.Domain.Entities.HumanResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(Guid Id);
        Task<Employee?> GetByEmailAsync(string Email);
        Task CreateAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteByIdAsync(Guid Id);
    }
}
