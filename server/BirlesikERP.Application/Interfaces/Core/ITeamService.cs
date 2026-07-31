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
        Task<IEnumerable<TeamDto>> GetAllAsync();
        Task CreateAsync(CreateTeamDto dto);
        Task DeleteByIdAsync(Guid Id);
    }
}
