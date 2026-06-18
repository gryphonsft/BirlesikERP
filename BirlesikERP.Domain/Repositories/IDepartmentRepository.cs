using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirlesikERP.Domain.Entities.Core;

namespace BirlesikERP.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(Guid Id);
        Task CreateAsync(Department department);
        Task UpdateAsync(Department department);
        Task DeleteByIdAsync(Guid Id);
        Task<IEnumerable<Department>> SearchAsync(string value);
    }
}
