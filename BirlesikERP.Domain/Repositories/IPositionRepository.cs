using BirlesikERP.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Domain.Repositories
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAllAsync();
        Task<Position?> GetByIdAsync(Guid Id);
        Task CreateAsync(Position position);
        Task UpdateAsync(Position position);
        Task DeleteByIdAsync(Guid Id);
    }
}
