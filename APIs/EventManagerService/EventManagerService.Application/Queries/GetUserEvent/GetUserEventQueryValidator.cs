using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetUserEvent
{
    public class GetUserEventQueryValidator : AbstractValidator<GetUserEventQuery>
    {
        public GetUserEventQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
