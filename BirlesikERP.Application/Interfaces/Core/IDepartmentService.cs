using BirlesikERP.Application.DTOs.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.Interfaces.Core
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllAsync();
        Task<DepartmentDto?> GetByIdAsync(Guid Id);
        Task<DepartmentDetailsDto> GetTeamsAsync(Guid Id);
        Task CreateAsync(CreateDepartmentDto dto);
        Task UpdateAsync(Guid Id, UpdateDepartmentDto dto);
        Task DeleteByIdAsync(Guid Id);
        Task<IEnumerable<DepartmentDto>> SearchAsync(string Name);
    }
}
