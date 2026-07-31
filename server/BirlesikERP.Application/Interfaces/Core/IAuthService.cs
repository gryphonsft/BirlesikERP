using BirlesikERP.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.Interfaces.Core
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> LoginAsync(LoginDto request);
        Task<RegisterResponseDto> RegisterAsync(RegisterDto request);
    }
}
