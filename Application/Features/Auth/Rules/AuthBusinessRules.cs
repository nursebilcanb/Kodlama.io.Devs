using Application.Features.ApplicationUsers.Rules;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules : ApplicationUserBusinessRules
    {
        public AuthBusinessRules(IApplicationUserRepository applicationUserRepository) : base(applicationUserRepository)
        {
        }

        public void LoginShouldBeSuccessful(bool loginResult)
        {
            if (loginResult != true) throw new BusinessException("Login is unsuccessful, try again");
        }

        public void UserShouldNotBeExistedToRegister(ApplicationUser applicationUser)
        {
            if (applicationUser != null) throw new BusinessException("This user already exists.");
        }
    }
}
