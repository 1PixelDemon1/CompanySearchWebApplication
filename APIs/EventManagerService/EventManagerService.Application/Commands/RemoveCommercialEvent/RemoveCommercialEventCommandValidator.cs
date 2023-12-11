using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.RemoveCommercialEvent
{
    public class RemoveCommercialEventCommandValidator : AbstractValidator<RemoveCommercialEventCommand>
    {
        public RemoveCommercialEventCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
