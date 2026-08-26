using BirlesikERP.Application.DTOs.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.Interfaces.Core
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamListDto>> GetAllAsync();
        Task<TeamDto?> GetByIdAsync(Guid Id);
        Task CreateAsync(CreateTeamDto dto);
        Task UpdateAsync(Guid Id,UpdateTeamDto dto);
        Task DeleteByIdAsync(Guid Id);
        Task DeleteAllAsync();
    }
}
