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
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Employee?> GetByIdAsync(Guid Id)
        {
            return await _context.Employee
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == Id);
        }
    }
}
