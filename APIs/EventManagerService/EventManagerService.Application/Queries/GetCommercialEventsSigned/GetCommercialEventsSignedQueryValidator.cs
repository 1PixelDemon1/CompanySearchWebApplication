using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetCommercialEventsSigned
{
    public class GetCommercialEventsSignedQueryValidator : AbstractValidator<GetCommercialEventsSignedQuery>
    {
        public GetCommercialEventsSignedQueryValidator()
        {
            RuleFor(query => query.UserId).GreaterThan(0);
        }
    }
}
