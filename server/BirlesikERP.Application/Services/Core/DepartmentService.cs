using AutoMapper;
using BirlesikERP.Application.DTOs.Core;
using BirlesikERP.Application.DTOs.HumanResources;
using BirlesikERP.Application.Exceptions;
using BirlesikERP.Application.Interfaces;
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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }
        public async Task<DepartmentDto?> GetByIdAsync(Guid Id)
        {
            var department = await _departmentRepository.GetByIdAsync(Id);

            if (department == null)

                return null;

            return new DepartmentDto
            {
                Name = department.Name,
                Description = department.Description,
                CreatedAt = department.CreatedAt
            };
        }
        public async Task<DepartmentDetailsDto> GetTeamsAsync(Guid Id)
        {
            var department = await _departmentRepository.GetTeamsAsync(Id);

            if (department == null)
                throw new Exception("Departman bulunamadı");

            return new DepartmentDetailsDto
            {
                Id = department.Id,
                Name = department.Name,
                TeamCount = department.Teams.Count,

                Teams = department.Teams.Select(t => new TeamSummaryDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    IsActive = t.IsActive,
                    CreatedAt = t.CreatedAt,

                    Employees = t.Employees.Select(e => new EmployeeSummaryDto
                    {
                        Id = e.Id,
                        FirstName = e.Person.FirstName,
                        LastName = e.Person.LastName
                    }).ToList()

                }).ToList()
            };
        }
        public async Task CreateAsync(CreateDepartmentDto dto)
        {
            var department = new Department
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            await _departmentRepository.CreateAsync(department);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid Id,UpdateDepartmentDto dto)
        {
            var department = await _departmentRepository.GetByIdAsync(Id);

            if (department == null)
                throw new Exception("Böyle bir departman bulunamadı");

            department.Name = dto.Name;
            department.Description = dto.Description;

            await _departmentRepository.UpdateAsync(department);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteByIdAsync(Guid Id)
        {
            var department = await _departmentRepository.GetByIdAsync(Id);

            if (department is null)
                throw new NotFoundException("Departman bulunamadı.");

            await _departmentRepository.DeleteByIdAsync(Id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<DepartmentDto>> SearchAsync(string value)
        {
            if (value.Length <= 3)
                return Enumerable.Empty<DepartmentDto>();

            var department = await _departmentRepository.SearchAsync(value);

            var result = department.Select(x => new DepartmentDto
            {
                Name = x.Name,
                Description = x.Description,
                CreatedAt = x.CreatedAt
            });

            return result;
        }
    }
}
