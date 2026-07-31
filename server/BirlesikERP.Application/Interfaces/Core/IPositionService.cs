using BirlesikERP.Application.DTOs.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.Interfaces.Core
{
    public interface IPositionService
    {
        Task<IEnumerable<PositionDto>> GetAllAsync();
        Task<PositionDto?> GetByIdAsync(Guid Id);
        Task CreateAsync(CreatePositionDto dto);
    }
}
