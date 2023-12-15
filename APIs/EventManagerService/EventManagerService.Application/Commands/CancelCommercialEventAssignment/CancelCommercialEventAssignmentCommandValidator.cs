using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.CancelCommercialEventAssignment
{
    public class CancelCommercialEventAssignmentCommandValidator : AbstractValidator<CancelCommercialEventAssignmentCommand>
    {
        public CancelCommercialEventAssignmentCommandValidator()
        {
            RuleFor(command => command.EventId).GreaterThan(0);
            RuleFor(command => command.UserId).GreaterThan(0);
        }
    }
}
