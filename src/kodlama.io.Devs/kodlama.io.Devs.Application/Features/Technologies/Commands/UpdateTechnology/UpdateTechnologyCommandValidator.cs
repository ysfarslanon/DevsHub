using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandValidator : AbstractValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(t => t.Id).NotNull();
            RuleFor(t => t.Id).NotEmpty();
            RuleFor(t => t.ProgrammingLanguageId).NotNull();
            RuleFor(t => t.ProgrammingLanguageId).NotEmpty();
            RuleFor(t => t.Name).NotNull();
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.Name).MinimumLength(2).MaximumLength(20);
        }
    }
}
