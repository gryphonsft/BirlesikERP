using AutoMapper;
using BirlesikERP.Application.DTOs.HumanResources;
using BirlesikERP.Application.Exceptions;
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
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository,IUnitOfWork unitOfWork,IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
        public async Task<IEnumerable<EmployeeSummaryDto>> GetAsync(int page, int pageSize)
        {
            var employees = await _employeeRepository.GetAsync(page,pageSize);

            if (employees is null)
                throw new NotFoundException("Kullanici bulunamadi");

            return employees.Select(x => new EmployeeSummaryDto
            {
                Id = x.Id,
                FirstName = x.Person.FirstName,
                LastName = x.Person.LastName
            });
        }
        public async Task<EmployeeDto?> GetByIdAsync(Guid Id)
        {
            var employees = await _employeeRepository.GetByIdAsync(Id);

            if (employees is null)
                throw new NotFoundException("Kullanici bulunamadi");

            return new EmployeeDto
            {
                Id = employees.Id,
                FirstName = employees.Person.FirstName,
                LastName = employees.Person.LastName,
                Email = employees.Person.Email,
                Phone = employees.Person.Phone,
                City = employees.Person.City,
                Age = employees.Person.Age,
                BirthDate = employees.Person.BirthDate,
                CreatedAt = employees.CreatedAt,
                IsActive = employees.IsActive,

                DepartmentName = employees.Department.Name,
                DepartmentId = employees.DepartmentId,

                TeamName = employees.Team?.Name,
                TeamId = employees.TeamId,

                PositionName = employees.Position.Name,
                PositionId = employees.PositionId
            };
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
        public async Task UpdateAsync(Guid Id,UpdateEmployeeDto dto)
        {
            var employee = await _employeeRepository.GetByIdAsync(Id);

            if (employee is null)
                throw new Exception("Employee bulunamadi");

            employee.IsActive = dto.IsActive;
            employee.Person.FirstName = dto.FirstName;
            employee.Person.LastName = dto.LastName;
            employee.Person.Email = dto.Email;
            employee.Person.Phone = dto.Phone;
            employee.Person.City = dto.City;
            employee.Person.Age = dto.Age;
            employee.Person.BirthDate = dto.BirthDate;

            await _employeeRepository.UpdateAsync(employee);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteByIdAsync(Guid Id)
        {
            var employee = await _employeeRepository.GetByIdAsync(Id);

            if (employee is null)
                throw new Exception("Employee bulunamadi");

            await _employeeRepository.DeleteByIdAsync(Id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<EmployeeSummaryDto>> SearchAsync(string value)
        {
            if (value.Length <= 3)
                //Buraya hata mesajı eklenecek.
                return Enumerable.Empty<EmployeeSummaryDto>();

            var employee = await _employeeRepository.SearchAsync(value);

            var result = employee.Select(x => new EmployeeSummaryDto
            {
                Id = x.Id,
                FirstName = x.Person.FirstName,
                LastName = x.Person.LastName
            });
            return result;
        }
    }
}
