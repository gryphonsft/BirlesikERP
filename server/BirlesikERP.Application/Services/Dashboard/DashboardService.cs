using BirlesikERP.Application.DTOs.Dashboard;
using BirlesikERP.Application.Interfaces.Dashboard;
using BirlesikERP.Domain.Repositories;

namespace BirlesikERP.Application.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IPositionRepository _positionRepository;

        public DashboardService(
            IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,
            ITeamRepository teamRepository,
            IPositionRepository positionRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _teamRepository = teamRepository;
            _positionRepository = positionRepository;
        }
        public async Task<DashboardDto> GetDashboardStatistic()
        {
            return new DashboardDto
            {
                EmployeeCount = await _employeeRepository.CountAsync(),
                DepartmentCount = await _departmentRepository.CountAsync(),
                TeamCount = await _teamRepository.CountAsync(),
                PositionCount = await _positionRepository.CountAsync()
            };
        }
    }
}
