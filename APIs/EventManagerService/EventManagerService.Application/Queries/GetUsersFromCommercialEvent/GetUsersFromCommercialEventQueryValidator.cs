using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetUsersFromEvent
{
    public class GetUsersFromCommercialEventQueryValidator : AbstractValidator<GetUsersFromEventQuery>
    {
        public GetUsersFromCommercialEventQueryValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
