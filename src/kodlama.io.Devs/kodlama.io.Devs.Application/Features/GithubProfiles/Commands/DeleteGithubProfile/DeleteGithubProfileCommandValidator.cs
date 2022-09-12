using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGithubProfile
{
    public class DeleteGithubProfileCommandValidator : AbstractValidator<DeleteGithubProfileCommand>
    {
        public DeleteGithubProfileCommandValidator()
        {
            RuleFor(gp => gp.Id).NotNull().NotEmpty();
        }
    }
}
