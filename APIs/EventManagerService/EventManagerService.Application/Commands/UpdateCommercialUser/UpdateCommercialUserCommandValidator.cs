using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.UpdateCommercialUser
{
    public class UpdateCommercialUserCommandValidator : AbstractValidator<UpdateCommercialUserCommand>
    {
        public UpdateCommercialUserCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Name).NotNull().NotEmpty();
        }
    }
}
