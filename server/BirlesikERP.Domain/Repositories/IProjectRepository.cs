using BirlesikERP.Domain.Entities.ProjectManagment;

namespace BirlesikERP.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(Guid Id);
        Task CreateAsync(Project project);
    }
}
