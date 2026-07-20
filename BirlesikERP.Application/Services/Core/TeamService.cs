using BirlesikERP.Application.DTOs.Core;
using BirlesikERP.Application.DTOs.HumanResources;
using BirlesikERP.Application.Interfaces.Core;
using BirlesikERP.Application.Interfaces.UnitOfWork;
using BirlesikERP.Domain.Entities.Core;
using BirlesikERP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.Services.Core
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TeamService(ITeamRepository teamRepository, IUnitOfWork unitOfWork)
        {
            _teamRepository = teamRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<TeamDto>> GetAllAsync()
        {
            var teams = await _teamRepository.GetAllAsync();

            return teams.Select(team => new TeamDto
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description,
                IsActive = team.IsActive,
                CreatedAt = team.CreatedAt,

                DepartmentId = team.DepartmentId,
                DepartmentName = team.Department.Name,

                Employees = team.Employees.Select(employee => new EmployeeDto
                {
                    Id = employee.Id,
                    CreatedAt = employee.CreatedAt,

                    IsActive = employee.IsActive,

                    DepartmentId = employee.DepartmentId,
                    TeamId = employee.TeamId,
                    PositionId = employee.PositionId,

                    FirstName = employee.Person.FirstName,
                    LastName = employee.Person.LastName,
                    Email = employee.Person.Email,
                    Phone = employee.Person.Phone,

                    PositionName = employee.Position.Name
                }).ToList()

            }).ToList();
        }
        public async Task CreateAsync(CreateTeamDto dto)
        {
            var team = new Team
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = DateTime.Now,
                IsActive = true,
                DepartmentId = dto.DepartmentId
            };
            await _teamRepository.CreateAsync(team);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteByIdAsync(Guid Id)
        {
            var team = await _teamRepository.GetByIdAsync(Id);

            if(team == null)
            {
                throw new Exception("Böyle bir takım bulunamadı");
            }
            await _teamRepository.DeleteByIdAsync(Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
