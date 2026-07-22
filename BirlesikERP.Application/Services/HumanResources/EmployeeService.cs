using BirlesikERP.Application.DTOs.HumanResources;
using BirlesikERP.Application.Interfaces.HumanResources;
using BirlesikERP.Application.Interfaces.UnitOfWork;
using BirlesikERP.Domain.Entities.HumanResources;
using BirlesikERP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.Services.HumanResources
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository employeeRepository,IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            return employees.Select(x => new EmployeeDto
            {
                Id = x.Id,
                FirstName = x.Person.FirstName,
                LastName = x.Person.LastName,
                Email = x.Person.Email,
                Phone = x.Person.Phone,
                City = x.Person.City,
                Age = x.Person.Age,
                BirthDate = x.Person.BirthDate,
                CreatedAt = x.CreatedAt,
                IsActive = x.IsActive,

                DepartmentName = x.Department.Name,
                DepartmentId = x.DepartmentId,

                TeamName = x.Team?.Name,
                TeamId = x.TeamId,

                PositionName = x.Position.Name,
                PositionId = x.PositionId

            });
        }
        public async Task CreateAsync(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                IsActive = true,
                DepartmentId = dto.DepartmentId,
                TeamId = dto.TeamId,
                PositionId = dto.PositionId,
                CreatedAt = DateTime.Now
            };

            employee.Person = new Person
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email =    dto.Email,
                Phone= dto.Phone,
                City =  dto.City,
                Age = dto.Age,
                BirthDate = dto.BirthDate,
                
            };

            await _employeeRepository.CreateAsync(employee);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
