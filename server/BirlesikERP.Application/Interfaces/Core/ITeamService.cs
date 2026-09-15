using BirlesikERP.Application.DTOs.Core;

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
        Task AssignEmployee(AssignEmployeeRequest request);
    }
}
