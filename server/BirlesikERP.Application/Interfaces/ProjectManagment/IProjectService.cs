using BirlesikERP.Application.DTOs.ProjectManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.Interfaces.ProjectManagment
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAllAsync();
        Task<ProjectDto?> GetByIdAsync(Guid Id);
        Task CreateAsync(CreateProjectDto dto);
    }
}
