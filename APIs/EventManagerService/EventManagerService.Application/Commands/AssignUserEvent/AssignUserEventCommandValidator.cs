using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.AssignUserEvent
{
    public class AssignUserEventCommandValidator : AbstractValidator<AssignUserEventCommand>
    {
        public AssignUserEventCommandValidator()
        {
            RuleFor(command => command.EventId).GreaterThan(0);
            RuleFor(command => command.UserId).GreaterThan(0);
        }
    }
}
