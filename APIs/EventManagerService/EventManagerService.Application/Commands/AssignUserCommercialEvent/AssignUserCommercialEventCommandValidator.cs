using EventManagerService.Application.Commands.AssignUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.AssignUserCommercialEvent
{
    public class AssignUserCommercialEventCommandValidator : AbstractValidator<AssignUserCommercialEventCommand>
    {
        public AssignUserCommercialEventCommandValidator()
        {
            RuleFor(command => command.EventId).GreaterThan(0);
            RuleFor(command => command.UserId).GreaterThan(0);
        }
    }
}
