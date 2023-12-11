using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.RemoveEventCategory
{
    public class RemoveEventCategoryCommandValidator : AbstractValidator<RemoveEventCategoryCommand>
    {
        public RemoveEventCategoryCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
