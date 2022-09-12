using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile
{
    public class UpdateGithubProfileCommandValidator : AbstractValidator<UpdateGithubProfileCommand>
    {
        public UpdateGithubProfileCommandValidator()
        {
            RuleFor(gp => gp.DeveloperUserId).NotNull();
            RuleFor(gp => gp.URL).NotNull();
            RuleFor(gp => gp.URL).MinimumLength(10);
        }
    }
}
