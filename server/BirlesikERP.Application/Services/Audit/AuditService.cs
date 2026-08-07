using BirlesikERP.Application.Exceptions;
using BirlesikERP.Application.Interfaces;
using BirlesikERP.Application.Interfaces.Audit;
using BirlesikERP.Domain.Entities.Audit;
using BirlesikERP.Domain.Repositories;

namespace BirlesikERP.Application.Services.Audit
{
    public class AuditService : IAuditService
    {
        private readonly IAuditRepository _auditRepository;
        private readonly ICurrentUserService _currentUserService;

        public AuditService(
            IAuditRepository auditRepository,
            ICurrentUserService currentUserService)
        {
            _auditRepository = auditRepository;
            _currentUserService = currentUserService;
        }

        public async Task LogAsync(
            AuditAction action,
            AuditEntity entity,
            Guid? entityId,
            string description,
            string? departmentName = null)
        {
            var currentUser = _currentUserService.GetCurrentUser();

            if (currentUser is null)
                throw new NotFoundException("Böyle bir 'currentUser' bulunamadı");

            var auditLog = new AuditLog
            {
                Action = action,
                Entity = entity,

                entityId = entityId,

                userId = currentUser.userId == Guid.Empty
                    ? null
                    : currentUser.userId,

                userName = string.IsNullOrWhiteSpace(currentUser.userName)
                    ? "System"
                    : currentUser.userName,

                Description = description,

                DepartmentName = departmentName,

                CreatedAt = DateTime.UtcNow
            };

            await _auditRepository.AddAsync(auditLog);
        }
    }
}