using BirlesikERP.Application.DTOs.Core;
using BirlesikERP.Domain.Entities.Core;
using BirlesikERP.Domain.Repositories;
using BirlesikERP.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Persistence.Repositories.Core
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _context.Department
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Department?> GetByIdAsync(Guid Id)
        {
            return await _context.Department
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Department?> GetTeamsAsync(Guid Id)
        {
            return await _context.Department
                .Include(x => x.Teams)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Department?> GetByNameAsync(string Name)
        {
            return await _context.Department.FirstOrDefaultAsync(x => x.Name == Name);
        }
        public async Task CreateAsync(Department department)
        {
            await _context.Department.AddAsync(department);
        }
        public async Task UpdateAsync(Department department)
        {
            _context.Department.Update(department);
        }
        public async Task DeleteByIdAsync(Guid Id)
        {
            var department = await GetByIdAsync(Id);
            if (department != null)
            {
                _context.Department.Remove(department);
            }
        }
        public async Task DeleteByNameAsync(string Name)
        {
            var department = await GetByNameAsync(Name);

            if(department != null)
            {
                _context.Department.Remove(department);
            }
        }
        public async Task<IEnumerable<Department>> SearchAsync(string value)
        {
            return await _context.Department
                .Where(x => x.Name.Contains(value))
                .ToListAsync();
        }
    }
}
