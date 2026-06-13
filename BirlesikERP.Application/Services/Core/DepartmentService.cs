using BirlesikERP.Application.DTOs.Core;
using BirlesikERP.Application.Interfaces;
using BirlesikERP.Application.Interfaces.Core;
using BirlesikERP.Application.Interfaces.UnitOfWork;
using BirlesikERP.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.Services.Core
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IRepository<Department> departmentRepository,IUnitOfWork unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();

            return departments.Select(x => new DepartmentDto
            {
                Name = x.Name,
                Description = x.Description,
                CreatedAt = x.CreatedAt
            }).ToList();
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

            await _departmentRepository.AddAsync(department);

            await _unitOfWork.SaveChangesAsync();
        }
        
        public async Task<DepartmentDto> GetByNameAsync(string Name)
        {
            var department = await _departmentRepository.
        }
    }
}
