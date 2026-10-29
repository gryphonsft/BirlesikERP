using BirlesikERP.Domain.Entities.ProjectManagment;
using BirlesikERP.Domain.Repositories;
using BirlesikERP.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BirlesikERP.Persistence.Repositories.ProjectManagment
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly AppDbContext _context;
        public ProjectRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Project
                .AsNoTracking()
                .Include(x => x.Customer)
                .ToListAsync();
        }
        public async Task<Project?> GetByIdAsync(Guid Id)
        {
            return await _context.Project
                .AsNoTracking()
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task CreateAsync(Project project)
        {
            await _context.Project.AddAsync(project);
        }
    }
}
