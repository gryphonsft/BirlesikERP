using BirlesikERP.Domain.Entities.Audit;
using BirlesikERP.Domain.Repositories;
using BirlesikERP.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BirlesikERP.Persistence.Repositories.Audit
{
    public class AuditRepository : IAuditRepository
    {
        private readonly AppDbContext _context;

        public AuditRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(AuditLog auditLog)
        {
            await _context.AuditLog.AddAsync(auditLog);
        }
        public async Task<List<AuditLog>> GetRecentAsync()
        {
            return await _context.AuditLog
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<AuditLog>> GetByActionAsync(AuditAction action)
        {
            return await _context.AuditLog
                .Where(x => x.Action == action)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
    }
}
