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

namespace Application.Features.ApplicationUsers.Commands.DeleteApplicationUser
{
    public class DeleteApplicationUserCommand : IRequest<DeletedApplicationUserDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { "ApplicationUser.Delete" };

        public class DeleteApplicationUserCommandHandler : IRequestHandler<DeleteApplicationUserCommand, DeletedApplicationUserDto>
        {
            private readonly IApplicationUserRepository _applicationUserRepository;
            private readonly IMapper _mapper;
            private readonly ApplicationUserBusinessRules _applicationUserBusinessRules;

            public DeleteApplicationUserCommandHandler(IApplicationUserRepository applicationUserRepository, IMapper mapper, ApplicationUserBusinessRules applicationUserBusinessRules)
            {
                _applicationUserRepository = applicationUserRepository;
                _mapper = mapper;
                _applicationUserBusinessRules = applicationUserBusinessRules;
            }

            public async Task<DeletedApplicationUserDto> Handle(DeleteApplicationUserCommand request, CancellationToken cancellationToken)
            {
                await _applicationUserBusinessRules.ApplicationUserMustBeExistedWhenRequested(request.Id);

                ApplicationUser mappedUser = _mapper.Map<ApplicationUser>(request);
                ApplicationUser deletedUser = await _applicationUserRepository.DeleteAsync(mappedUser);
                DeletedApplicationUserDto deletedApplicationUserDto = _mapper.Map<DeletedApplicationUserDto>(deletedUser);

                return deletedApplicationUserDto;
            }
        }

    }
}
