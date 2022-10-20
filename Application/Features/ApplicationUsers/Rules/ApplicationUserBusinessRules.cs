using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Rules
{
    public class ApplicationUserBusinessRules
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        public ApplicationUserBusinessRules(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }

        public async Task ApplicationUserNameCanNotBetDuplicatedWhenInserted(ApplicationUser applicationUser)
        {
            IPaginate<ApplicationUser> result = await _applicationUserRepository.GetListAsync(l => l.User.FirstName == applicationUser.User.FirstName);
            if (result.Items.Any()) throw new BusinessException("Application user already exists.");
        }

        public async Task ApplicationUserMustBeExistedWhenRequested(int id)
        {
            IPaginate<ApplicationUser> result = await _applicationUserRepository.GetListAsync(l => l.Id == id);
            if (!result.Items.Any()) throw new BusinessException("Application user should be existed");
        }
    }
}
