using BirlesikERP.Application.DTOs.HumanResources;
using BirlesikERP.Application.Interfaces.HumanResources;
using BirlesikERP.Application.Interfaces.UnitOfWork;
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
                DepartmentName = x.Department.Name,
                TeamName = x.Team?.Name,
                PositionName = x.Position.Name
            });
        }
        //public async Task CreateAsync(CreateEmployeeDto dto)
        //{

        //}
    }
}
