using Application.Features.Auth.Dtos;
using Application.Features.Auth.Models;
using Application.Features.Auth.Rules;
using Application.Services.AuthenticationServices;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.RegisterCommand
{
    public class RegisterCommand : IRequest<RegisteredModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GithubAddress { get; set; }
        public string IpAddress { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredModel>
        {
            private readonly IAuthenticationService _authenticationService;
            private readonly IMapper _mapper;
            private readonly AuthBusinessRules _authBusinessRules;

            public RegisterCommandHandler(IAuthenticationService authenticationService, IMapper mapper, AuthBusinessRules authBusinessRules)
            {
                _authenticationService = authenticationService;
                _mapper = mapper;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<RegisteredModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                var existingUser = await _authenticationService.GetUserByEmailAsync(request.Email);
                _authBusinessRules.UserShouldNotBeExistedToRegister(existingUser);

                var result = new RegisteredModel();
                var createdApplicationUser = await _authenticationService.RegisterAsync(request);
                
                result.ApplicationUser = _mapper.Map<RegisteredDto>(createdApplicationUser);
                result.AccessToken = await _authenticationService.CreateAccessToken(createdApplicationUser);
                result.RefreshToken = await _authenticationService.CreateRefreshToken(createdApplicationUser.User, request.IpAddress);

                await _authenticationService.AddRefreshToken(result.RefreshToken);

                return result;
            }
        }
    }
}
