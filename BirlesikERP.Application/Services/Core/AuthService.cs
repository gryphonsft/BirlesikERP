using BirlesikERP.Application.DTOs.Auth;
using BirlesikERP.Application.Interfaces;
using BirlesikERP.Application.Interfaces.Core;
using BirlesikERP.Domain.Entities.Core.AppUser;
using Microsoft.AspNetCore.Identity;

namespace BirlesikERP.Application.Services.Core
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        
        public AuthService(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<LoginResponseDto?> LoginAsync(LoginDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                return null;

            var result = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!result)
                return null;

            var token = _tokenService.GenerateToken(user);

            return new LoginResponseDto
            {
                AccessToken = token,
                ExpiresAt = DateTime.UtcNow.AddMinutes(60)
            };
        }

        public async Task<RegisterResponseDto> RegisterAsync(RegisterDto request)
        {
            var existinguser = await _userManager.FindByNameAsync(request.Username);

            if (existinguser != null)
            {
                return new RegisterResponseDto
                {
                    Success = false,
                    Message = "Bu kullanici adi zaten kullaniliyor."
                };
            }

            var user = new AppUser
            {
                UserName = request.Username,
                Email = request.Email,
                FullName = request.Fullname
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new Exception(
                    string.Join(", ", result.Errors.Select(x => x.Description)));
            }

            return new RegisterResponseDto
            {
                Success = true,
                Message = "Kullanici basariyla olusturuldu.",
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email
            };    
        }
    }
}
