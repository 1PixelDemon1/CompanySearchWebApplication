using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventsByEventCategory
{
    public class GetEventsByEventCategoryQueryValidator : AbstractValidator<GetEventsByEventCategoryQuery>
    {
        public GetEventsByEventCategoryQueryValidator()
        {
            RuleFor(command => command.EventCategoryId).GreaterThan(0);
        }
    }
}
