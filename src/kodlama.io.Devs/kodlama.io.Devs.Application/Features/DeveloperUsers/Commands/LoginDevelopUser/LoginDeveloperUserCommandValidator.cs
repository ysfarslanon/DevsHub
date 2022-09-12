using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.DeveloperUsers.Commands.LoginDevelopUser
{
    public class LoginDeveloperUserCommandValidator : AbstractValidator<LoginDeveloperUserCommand>
    {
        public LoginDeveloperUserCommandValidator()
        {
            RuleFor(u => u.Email).NotEmpty().NotNull();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Password).NotEmpty().NotNull();
        }
    }
}
