using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventCategoriesFromUserEvent
{
    public class GetEventCategoriesFromUserEventQueryValidator : AbstractValidator<GetEventCategoriesFromUserEventQuery>
    {
        public GetEventCategoriesFromUserEventQueryValidator()
        {
            RuleFor(command => command.UserEventId).GreaterThan(0);
        }
    }
}
