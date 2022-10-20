using Application.Features.Auth.Commands.LoginCommand;
using Application.Features.Auth.Commands.RegisterCommand;
using Application.Services.AuthRepositories;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthenticationService(IApplicationUserRepository applicationUserRepository, IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository)
        {
            _applicationUserRepository = applicationUserRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            var addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
            return addedRefreshToken;
        }

        public async Task<AccessToken> CreateAccessToken(ApplicationUser applicationUser)
        {
            var claims = _applicationUserRepository.GetClaims(applicationUser);
            var accessToken = _tokenHelper.CreateToken(applicationUser.User, claims);
            return accessToken;
        }

        public async Task<RefreshToken> CreateRefreshToken(User createdApplicationUser, string ipAddress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(createdApplicationUser, ipAddress);
            return await Task.FromResult(refreshToken);
        }

        public Task<ApplicationUser?> GetUserByEmailAsync(string email)
        {
            return _applicationUserRepository.GetAsync(u => u.User.Email == email);
        }

        public Task<bool> LoginAsync(LoginCommand loginCommand, ApplicationUser existingUser)
        {
            var result = HashingHelper.VerifyPasswordHash(loginCommand.Password, existingUser.User.PasswordHash, existingUser.User.PasswordSalt);
            return Task.FromResult(result);
        }

        public async Task<ApplicationUser> RegisterAsync(RegisterCommand registerCommand)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(registerCommand.Password, out passwordHash, out passwordSalt);

            var appUser = _mapper.Map<ApplicationUser>(registerCommand);
            appUser.User = _mapper.Map<User>(registerCommand);
            appUser.User.PasswordHash = passwordHash;
            appUser.User.PasswordSalt = passwordSalt;
            appUser.User.Status = true;

            var createdUser = await _userRepository.AddAsync(appUser.User);
            appUser.UserId = createdUser.Id;
            var createdAppUser = await _applicationUserRepository.AddAsync(appUser);

            return createdAppUser;
        }
    }
}
