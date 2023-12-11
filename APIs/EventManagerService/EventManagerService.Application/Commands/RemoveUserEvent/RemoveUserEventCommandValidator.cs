using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.RemoveUserEvent
{
    public class RemoveUserEventCommandValidator : AbstractValidator<RemoveUserEventCommand>
    {
        public RemoveUserEventCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
