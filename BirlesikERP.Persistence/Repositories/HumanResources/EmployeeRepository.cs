using BirlesikERP.Domain.Entities.HumanResources;
using BirlesikERP.Domain.Repositories;
using BirlesikERP.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Persistence.Repositories.HumanResources
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employee
                 .Include(x => x.Person)
                 .Include(x => x.Department)
                 .Include(x => x.Team)
                 .Include(x => x.Position)
                 .AsNoTracking()
                 .ToListAsync();
        }
        public async Task<Employee?> GetByIdAsync(Guid Id)
        {
            return await _context.Employee
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == Id);
        }
        public async Task<Employee?> GetByEmailAsync(string Email)
        {
            return await _context.Employee.FirstOrDefaultAsync(e => e.Person.Email == Email);
        }
        public async Task CreateAsync(Employee employee)
        {
            await _context.Employee.AddAsync(employee);
        }
        public async Task UpdateAsync(Employee employee)
        {
           _context.Employee.Update(employee);
        }
        public async Task DeleteByIdAsync(Guid Id)
        {
            var employee = await GetByIdAsync(Id);

            if (employee != null)
            {
                _context.Employee.Remove(employee);
            }
        }
    }
}
