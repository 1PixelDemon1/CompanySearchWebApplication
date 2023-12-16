using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventsCreatedByUser
{
    public class GetEventsCreatedByUserQueryValidator : AbstractValidator<GetEventsCreatedByUserQuery>
    {
        public GetEventsCreatedByUserQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
