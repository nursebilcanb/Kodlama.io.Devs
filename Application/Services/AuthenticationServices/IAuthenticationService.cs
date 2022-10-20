using Application.Features.Auth.Commands.LoginCommand;
using Application.Features.Auth.Commands.RegisterCommand;
using Core.Security.Entities;
using Core.Security.JWT;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
        Task<AccessToken> CreateAccessToken(ApplicationUser applicationUser);
        Task<RefreshToken> CreateRefreshToken(User createdApplicationUser, string ipAddress);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<bool> LoginAsync(LoginCommand loginCommand, ApplicationUser existingUser);
        Task<ApplicationUser> RegisterAsync(RegisterCommand registerCommand);
    }
}
