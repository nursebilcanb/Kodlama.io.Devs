using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Commands.UpdateApplicationUser
{
    public class UpdateApplicationUserCommandValidator : AbstractValidator<UpdateApplicationUserCommand>
    {
        public UpdateApplicationUserCommandValidator()
        {
            RuleFor(u => u.Id).NotEmpty();
            RuleFor(u => u.GithubAddress).NotEmpty();
            RuleFor(u => u.UserId).NotEmpty();
            RuleFor(u => u.Roles).NotEmpty();
        }
    }
}
