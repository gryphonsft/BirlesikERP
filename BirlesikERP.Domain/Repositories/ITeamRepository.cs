using BirlesikERP.Domain.Entities.Core;

namespace BirlesikERP.Domain.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team?> GetByIdAsync(Guid Id);
        Task<Team?> GetByNameAsync(string Name);
        Task CreateAsync(Team team);
        Task UpdateAsync(Team team);
        Task DeleteByIdAsync(Guid Id);
        Task DeleteByNameAsync(string Name);
        Task<IEnumerable<Team>> SearchAsync(string value);
    }
}