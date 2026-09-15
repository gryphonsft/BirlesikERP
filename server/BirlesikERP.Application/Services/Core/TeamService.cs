using BirlesikERP.Application.DTOs.Core;
using BirlesikERP.Application.DTOs.HumanResources;
using BirlesikERP.Application.Exceptions;
using BirlesikERP.Application.Interfaces.Core;
using BirlesikERP.Application.Interfaces.UnitOfWork;
using BirlesikERP.Domain.Entities.Core;
using BirlesikERP.Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace BirlesikERP.Application.Services.Core
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TeamService(ITeamRepository teamRepository, IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _teamRepository = teamRepository;
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<TeamListDto>> GetAllAsync()
        {
            var teams = await _teamRepository.GetAllAsync();

            return teams.Select(team => new TeamListDto
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description,
                IsActive = team.IsActive,
                DepartmentId = team.DepartmentId,
                Department = team.Department is null ? null : new DepartmentSummaryDto
                {
                    Name = team.Department.Name,
                    Description = team.Department.Description
                },
                Employees = team.Employees.Select(e => new EmployeeSummaryDto
                {
                    FirstName = e.Person.FirstName,
                    LastName = e.Person.LastName,
                    PositionName = e.Position?.Name
                }).ToList(),
                CreatedAt = team.CreatedAt
            }).ToList();
        }
        public async Task<TeamDto?> GetByIdAsync(Guid Id)
        {
            var team = await _teamRepository.GetByIdAsync(Id);

            if (team is null)
            {
                throw new NotFoundException("Takım bulunamadı");
            }
             
            return new TeamDto
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
                    DepartmentName = employee.Department.Name,

                    TeamId = employee.TeamId,
                    PositionId = employee.PositionId,

                    FirstName = employee.Person.FirstName,
                    LastName = employee.Person.LastName,
                    Email = employee.Person.Email,
                    Phone = employee.Person.Phone,
                    City = employee.Person.City,
                    Age = employee.Person.Age,
                    BirthDate = employee.Person.BirthDate,

                    PositionName = employee.Position.Name
                }).ToList()
            };
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
        public async Task UpdateAsync(Guid Id,UpdateTeamDto dto)
        {
            var team = await _teamRepository.GetForUpdateAsync(Id);

            if (team is null)
            {
                throw new NotFoundException("Böyle bir takım bulunamadı");
            }
              
            team.Name = dto.Name;
            team.Description = dto.Description;
            team.IsActive = dto.IsActive;

            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteByIdAsync(Guid Id)
        {
            var team = await _teamRepository.GetByIdAsync(Id);

            if (team is null)
            {
                throw new NotFoundException("Böyle bir takım bulunamadı");
            }
            await _teamRepository.DeleteByIdAsync(Id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteAllAsync()
        {
            await _teamRepository.DeleteAllAsync();
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task AssignEmployee(AssignEmployeeRequest request)
        {
            var team = await _teamRepository.GetByIdAsync(request.teamId);

            if (team is null)
            {
                throw new NotFoundException("Takım bulunamadı");
            }

            var employee = await _employeeRepository.GetByIdAsync(request.employeeId);

            if (employee is null)
            {
                throw new NotFoundException("Calisan bulunamadı");
            }

            if (team.Employees.Any(e => e.Id == employee.Id))
            {
                throw new BadHttpRequestException("Bu calisan zaten bu takıma atanmış");
            }

            if (employee.TeamId is not null)
            {
                throw new BadHttpRequestException("Bu calisan baska bir takıma atanmış");
            }

            employee.TeamId = request.teamId;
            await _employeeRepository.UpdateAsync(employee);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
