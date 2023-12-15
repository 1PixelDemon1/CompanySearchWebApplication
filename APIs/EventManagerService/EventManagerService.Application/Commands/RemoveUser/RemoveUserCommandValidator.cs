using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.RemoveUser
{
    public class RemoveUserCommandValidator : AbstractValidator<RemoveUserCommand>
    {
        public RemoveUserCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);            
        }
    }
}
