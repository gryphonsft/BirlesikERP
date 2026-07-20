using BirlesikERP.Application.DTOs.Core;
using BirlesikERP.Application.Interfaces.Core;
using BirlesikERP.Application.Interfaces.UnitOfWork;
using BirlesikERP.Domain.Entities.Core;
using BirlesikERP.Domain.Repositories;

namespace BirlesikERP.Application.Services.Core
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PositionService(IPositionRepository positionRepository, IUnitOfWork unitOfWork)
        {
            _positionRepository = positionRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<PositionDto>> GetAllAsync()
        {
            var position = await _positionRepository.GetAllAsync();

            //Bu Mapping sayesinde, Position bilgileriyle beraber, bağlı olduğu departman bilgileri de geliyor.
            return position.Select(x => new PositionDto
            {
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                Department = new DepartmentDto
                {
                    Name = x.Department.Name,
                    Description = x.Department.Description,
                    CreatedAt = x.Department.CreatedAt
                }
            }).ToList();
        }
        public async Task<PositionDto?> GetByIdAsync(Guid id)
        {
            var position = await _positionRepository.GetByIdAsync(id);

            if (position == null)
                return null;

            return new PositionDto
            {
                Name = position.Name,
                CreatedAt = position.CreatedAt,
                Department = new DepartmentDto
                {
                    Name = position.Department.Name,
                    Description = position.Department.Description,
                    CreatedAt = position.Department.CreatedAt
                }
            };
        }
        public async Task CreateAsync(CreatePositionDto dto)
        {
            var position = new Position
            {
                Name = dto.Name,
                DepartmentId = dto.DepartmentId,
                CreatedAt = DateTime.Now
            };

            await _positionRepository.CreateAsync(position);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
