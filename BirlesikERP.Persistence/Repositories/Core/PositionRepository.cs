using BirlesikERP.Domain.Entities.Core;
using BirlesikERP.Domain.Repositories;
using BirlesikERP.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Persistence.Repositories.Core
{
    public class PositionRepository : IPositionRepository
    {
        private readonly AppDbContext _context;

        public PositionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            return await _context.Position
                .AsNoTracking()
                .Include(p => p.Department)
                .ToListAsync();
        }
        public async Task<Position?> GetByIdAsync(Guid Id)
        {
            return await _context.Position
                .AsNoTracking()
                .Include(p=> p.Department)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task CreateAsync(Position position)
        {
            await _context.AddAsync(position);
        }
        public async Task UpdateAsync(Position position)
        {
            _context.Position.Update(position);
        }
        public async Task DeleteByIdAsync(Guid Id)
        {
            var position = await GetByIdAsync(Id);

            if(position != null)
            {
                _context.Position.Remove(position);
            }
        }
    }
}
