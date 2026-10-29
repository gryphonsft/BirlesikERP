using BirlesikERP.Application.DTOs.ProjectManagment;
using BirlesikERP.Application.Interfaces.ProjectManagment;
using BirlesikERP.Application.Interfaces.UnitOfWork;
using BirlesikERP.Domain.Entities.ProjectManagment;
using BirlesikERP.Domain.Repositories;

namespace BirlesikERP.Application.Services.ProjectManagment
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IProjectRepository projectRepository,IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var projects = await _projectRepository.GetAllAsync();

            return projects.Select(x => new ProjectDto
            {
                Name = x.Name,
                Description = x.Description,
                IsActive = x.IsActive,
                DueDate = x.DueDate
            }).ToList();
        }
        public async Task<ProjectDto?> GetByIdAsync(Guid Id)
        {
            var project = await _projectRepository.GetByIdAsync(Id);

            if (project is null)
                return null;

            return new ProjectDto
            {
                Name = project.Name,
                Description = project.Description,
                IsActive = project.IsActive,
                DueDate = project.DueDate
            };
        }
        public async Task CreateAsync(CreateProjectDto dto)
        {
            var project = new Project
            {
                Name = dto.Name,
                Description = dto.Description,
                IsActive = dto.IsActive,
                DueDate = dto.DueDate,
                CustomerId = dto.CustomerId
            };
            await _projectRepository.CreateAsync(project);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
