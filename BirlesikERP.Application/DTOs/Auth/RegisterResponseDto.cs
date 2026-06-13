using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.DTOs.Auth
{
    public class RegisterResponseDto
    {
        public bool Success { get; init; }
        public string Message { get; init; } = string.Empty;

        public Guid? Id { get; init; }
        public string? Username { get; init; }
        public string? Email { get; init; }
    }
}
