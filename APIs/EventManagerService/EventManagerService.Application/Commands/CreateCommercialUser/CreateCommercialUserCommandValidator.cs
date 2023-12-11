using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.CreateCommercialUser
{
    public class CreateCommercialUserCommandValidator : AbstractValidator<CreateCommercialUserCommand>
    {
        public CreateCommercialUserCommandValidator()
        {
            RuleFor(command => command.Name).NotNull().NotEmpty();
        }
    }
}
