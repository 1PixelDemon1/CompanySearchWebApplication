using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetCommercialEvent
{
    public class GetCommercialEventQueryValidator : AbstractValidator<GetCommercialEventQuery>
    {
        public GetCommercialEventQueryValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }   
    }
}
