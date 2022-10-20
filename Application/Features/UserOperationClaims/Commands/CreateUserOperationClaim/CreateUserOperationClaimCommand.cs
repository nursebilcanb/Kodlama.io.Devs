using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.AuthRepositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>, ISecuredRequest
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public string[] Roles => new[] { "Admin" };

        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IUserRepository _userRepository;
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IUserRepository userRepository, IOperationClaimRepository operationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _userRepository = userRepository;
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(t => t.Id == request.UserId);
                _userOperationClaimBusinessRules.UserShouldBeExistedWhenRequested(user.Id);
                

                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(t => t.Id == request.OperationClaimId);
                _userOperationClaimBusinessRules.OperationClaimShouldBeExistedWhenRequested(operationClaim.Id);

                UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim createdUserOperationClaim = await _userOperationClaimRepository.AddAsync(mappedUserOperationClaim);
                CreatedUserOperationClaimDto createdUserOperationClaimDto = _mapper.Map<CreatedUserOperationClaimDto>(createdUserOperationClaim);

                return createdUserOperationClaimDto;

            }
        }

    }
}
