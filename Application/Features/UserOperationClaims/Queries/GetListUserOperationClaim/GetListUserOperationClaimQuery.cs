using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.AuthRepositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim
{
    public class GetListUserOperationClaimQuery : IRequest<UserOperationClaimListModel>, ISecuredRequest
    {
        public int UserId { get; set; }
        public PageRequest PageRequest { get; set; }
        public string[] Roles => new[] {"Admin"};

        public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery, UserOperationClaimListModel>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public GetListUserOperationClaimQueryHandler(IUserRepository userRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(u => u.Id == request.UserId);
                _userOperationClaimBusinessRules.UserShouldBeExistedWhenRequested(user.Id);

                 IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(
                                              u => u.UserId == request.UserId,
                                              include: u => u.Include(o => o.OperationClaim),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize);

                UserOperationClaimListModel mappedUserOperationClaimListModel = _mapper.Map<UserOperationClaimListModel>(userOperationClaims);
                
                return mappedUserOperationClaimListModel;   
            }
        }

    }
}
