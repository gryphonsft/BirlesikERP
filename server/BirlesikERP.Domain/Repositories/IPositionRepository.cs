using BirlesikERP.Domain.Entities.Core;

namespace BirlesikERP.Domain.Repositories
{
    public interface IPositionRepository : IRepository<Position>
    {
        Task<IEnumerable<Position>> GetAllAsync();
        Task<Position?> GetByIdAsync(Guid Id);
        Task CreateAsync(Position position);
        Task UpdateAsync(Position position);
        Task DeleteByIdAsync(Guid Id);
    }
}
