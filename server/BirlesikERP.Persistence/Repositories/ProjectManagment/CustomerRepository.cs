using BirlesikERP.Domain.Entities.ProjectManagment;
using BirlesikERP.Domain.Repositories;
using BirlesikERP.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BirlesikERP.Persistence.Repositories.ProjectManagment
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customer
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task CreateAsync(Customer customer)
        {
            await _context.Customer.AddAsync(customer);
        }
    }
}
