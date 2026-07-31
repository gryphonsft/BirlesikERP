using BirlesikERP.Application.DTOs.HumanResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.Interfaces.HumanResources
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<IEnumerable<EmployeeSummaryDto>> GetAsync(int page, int pageSize);
        Task<EmployeeDto?> GetByIdAsync(Guid Id);
        Task CreateAsync(CreateEmployeeDto dto);
        Task<IEnumerable<EmployeeSummaryDto>> SearchAsync(string value);
    }
}
