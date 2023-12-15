using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Name).NotNull().NotEmpty();
            RuleFor(command => command.Age).GreaterThanOrEqualTo(0);
            RuleFor(command => (int)command.Gender).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
        }
    }
}
