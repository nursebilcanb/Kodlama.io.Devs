using Application.Services.AuthRepositories;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        public async Task UserShouldBeExistedWhenRequested(int userId)
        {
            IPaginate<UserOperationClaim> result = await _userOperationClaimRepository.GetListAsync(l => l.UserId == userId);
            if (!result.Items.Any()) throw new BusinessException("User should be existed");
        }

        public async Task OperationClaimShouldBeExistedWhenRequested(int operationClaimId)
        {
            IPaginate<UserOperationClaim> result = await _userOperationClaimRepository.GetListAsync(l => l.UserId == operationClaimId );
            if (!result.Items.Any()) throw new BusinessException("Operation claim should be existed");
        }
    }
}
