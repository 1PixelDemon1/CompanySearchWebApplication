using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.CreateEventCategory
{
    public class CreateEventCategoryCommandValidator : AbstractValidator<CreateEventCategoryCommand>
    {
        public CreateEventCategoryCommandValidator()
        {
            RuleFor(command => command.Name).NotNull().NotEmpty();
        }
    }
}
