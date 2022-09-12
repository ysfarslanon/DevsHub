using FluentValidation;
using kodlama.io.Devs.Application.Features.DeveloperUsers.Commands.LoginDeveloperUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.DeveloperUsers.Commands.CreateDeveloperUser
{
    public class CreateDeveloperUserCommandValidator : AbstractValidator<CreateDeveloperUserCommand>
    {
        public CreateDeveloperUserCommandValidator()
        {
            RuleFor(u => u.Email).NotEmpty().NotNull();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Password).NotEmpty().NotNull();
            RuleFor(u => u.Password).MinimumLength(8);
            RuleFor(u => u.FirstName).NotEmpty().NotNull();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).NotEmpty().NotNull();
            RuleFor(u => u.LastName).MinimumLength(2);

        }
    }
}
