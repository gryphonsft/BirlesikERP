using BirlesikERP.Domain.Entities.Core;
using BirlesikERP.Domain.Repositories;
using BirlesikERP.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BirlesikERP.Persistence.Repositories.Core
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _context;

        public TeamRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _context.Team.ToListAsync();
        }
        public async Task<Team?> GetByIdAsync(Guid Id)
        {
            return await _context.Team.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Team?> GetByNameAsync(string Name)
        {
            return await _context.Team.FirstOrDefaultAsync(x => x.Name == Name);
        }
        public async Task CreateAsync(Team team)
        {
            await _context.Team.AddAsync(team);
        }
        public async Task UpdateAsync(Team team)
        {
            _context.Team.Update(team);
        }
        public async Task DeleteByIdAsync(Guid Id)
        {
            var team = await GetByIdAsync(Id);
            if (team != null)
            {
                _context.Team.Remove(team);
            }
        }
        public async Task DeleteByNameAsync(string Name)
        {
            var team = await GetByNameAsync(Name);

            if(team != null)
            {
                _context.Team.Remove(team);
            }
        }
        public async Task<IEnumerable<Team>> SearchAsync(string value)
        {
            return await _context.Team
                .Where(x => x.Name.Contains(value))
                .ToListAsync();
        }
    }
}