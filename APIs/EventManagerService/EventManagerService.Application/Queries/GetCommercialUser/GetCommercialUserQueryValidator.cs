using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetCommercialUser
{
    public class GetCommercialUserQueryValidator : AbstractValidator<GetCommercialUserQuery>
    {
        public GetCommercialUserQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
