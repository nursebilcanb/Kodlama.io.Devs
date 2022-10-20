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

namespace Application.Features.Auth.Commands.LoginCommand
{
    public class LoginCommand : IRequest<LoggedInModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedInModel>
        {
            private readonly IAuthenticationService _authenticationService;
            private readonly IMapper _mapper;
            private readonly AuthBusinessRules _autBusinessRules;

            public LoginCommandHandler(IAuthenticationService authenticationService, IMapper mapper, AuthBusinessRules authBusinessRules)
            {
                _authenticationService = authenticationService;
                _mapper = mapper;
                _autBusinessRules = authBusinessRules;
            }

            public async Task<LoggedInModel> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var existingUser = await _authenticationService.GetUserByEmailAsync(request.Email);
                await _autBusinessRules.ApplicationUserMustBeExistedWhenRequested(existingUser.Id);

                var result = new LoggedInModel();
                var loginResult = await _authenticationService.LoginAsync(request, existingUser);
                _autBusinessRules.LoginShouldBeSuccessful(loginResult);

                result.AccessToken = await _authenticationService.CreateAccessToken(existingUser);
                result.ApplicationUser = _mapper.Map<LoggedInDto>(existingUser);

                return result;
                
            }
        }


    }
}
