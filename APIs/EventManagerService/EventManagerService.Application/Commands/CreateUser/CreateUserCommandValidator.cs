using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(command => command.Name).NotNull().NotEmpty();
            RuleFor(command => command.Age).GreaterThanOrEqualTo(0);
            RuleFor(command => (int) command.Gender).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
        }
    }
}
