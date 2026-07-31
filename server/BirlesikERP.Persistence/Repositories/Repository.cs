using BirlesikERP.Domain.Repositories;
using BirlesikERP.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BirlesikERP.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }
    }
}
