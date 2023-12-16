using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetUsersFromEvent
{
    public class GetUsersFromEventQueryValidator : AbstractValidator<GetUsersFromEventQuery>
    {
        public GetUsersFromEventQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
