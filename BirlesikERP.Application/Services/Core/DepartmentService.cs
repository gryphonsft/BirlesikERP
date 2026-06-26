using BirlesikERP.Application.DTOs.Core;
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

        public DepartmentService(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();

            return departments.Select(x => new DepartmentDto
            {
                Name = x.Name,
                Description = x.Description,
                CreatedAt = x.CreatedAt
            }).ToList();
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

                Teams = department.Teams.Select(t => new TeamDto
                {
                    Id = t.Id,
                    Name = t.Name
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

            if(department == null)
            {
                throw new Exception("Böyle bir departman bulunamadı");
            }
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
