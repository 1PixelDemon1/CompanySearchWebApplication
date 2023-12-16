using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventCategory
{
    public class GetEventCategoryQueryValidator : AbstractValidator<GetEventCategoryQuery>
    {
        public GetEventCategoryQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
