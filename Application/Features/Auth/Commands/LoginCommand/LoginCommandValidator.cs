using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.LoginCommand
{
    public class LoginCommandValidator: AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(l => l.Email).NotEmpty().EmailAddress();
            RuleFor(l => l.Password).NotEmpty();
        }
    }
}
