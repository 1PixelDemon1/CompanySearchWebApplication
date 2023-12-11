using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.UpdateEventCategory
{
    public class UpdateEventCategoryCommandValidator : AbstractValidator<UpdateEventCategoryCommand>
    {
        public UpdateEventCategoryCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Name).NotNull().NotEmpty();
        }
    }
}
