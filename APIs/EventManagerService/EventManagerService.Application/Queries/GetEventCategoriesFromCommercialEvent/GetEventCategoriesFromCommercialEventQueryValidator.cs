using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventCategoriesFromCommercialEvent
{
    public class GetEventCategoriesFromCommercialEventQueryValidator : AbstractValidator<GetEventCategoriesFromCommercialEventQuery>
    {
        public GetEventCategoriesFromCommercialEventQueryValidator()
        {
            RuleFor(command => command.CommercialEventId).GreaterThan(0);
        }
    }
}
