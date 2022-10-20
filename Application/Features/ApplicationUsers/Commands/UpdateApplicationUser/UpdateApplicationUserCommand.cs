using Application.Features.ApplicationUsers.Dtos;
using Application.Features.ApplicationUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Commands.UpdateApplicationUser
{
    public class UpdateApplicationUserCommand : IRequest<UpdatedApplicationUserDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubAddress { get; set; }

        public string[] Roles => new[] { "ApplicationUser.Update" };

        public class UpdateApplicationUserCommandHandler : IRequestHandler<UpdateApplicationUserCommand, UpdatedApplicationUserDto>
        {
            private readonly IApplicationUserRepository _applicationUserRepository;
            private readonly IMapper _mapper;
            private readonly ApplicationUserBusinessRules _applicationUserBusinessRules;

            public UpdateApplicationUserCommandHandler(IApplicationUserRepository applicationUserRepository, IMapper mapper, ApplicationUserBusinessRules applicationUserBusinessRules)
            {
                _applicationUserRepository = applicationUserRepository;
                _mapper = mapper;
                _applicationUserBusinessRules = applicationUserBusinessRules;
            }

            public async Task<UpdatedApplicationUserDto> Handle(UpdateApplicationUserCommand request, CancellationToken cancellationToken)
            {
                ApplicationUser mappedUser = _mapper.Map<ApplicationUser>(request);
                await _applicationUserBusinessRules.ApplicationUserNameCanNotBetDuplicatedWhenInserted(mappedUser);

                ApplicationUser updatedUser = await _applicationUserRepository.UpdateAsync(mappedUser);
                UpdatedApplicationUserDto updatedUserDto = _mapper.Map<UpdatedApplicationUserDto>(updatedUser);

                return updatedUserDto;

            }
        }

    }
}
