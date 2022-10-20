using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Commands.DeleteApplicationUser
{
    public class DeleteApplicationUserCommandValidator : AbstractValidator<DeleteApplicationUserCommand>
    {
        public DeleteApplicationUserCommandValidator()
        {
            RuleFor(u => u.Id).NotEmpty();
            RuleFor(u => u.Roles).NotEmpty();
        }
    }
}
