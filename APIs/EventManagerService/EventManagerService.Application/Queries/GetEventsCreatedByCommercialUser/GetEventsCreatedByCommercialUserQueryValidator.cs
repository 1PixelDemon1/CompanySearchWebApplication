﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventsCreatedByCommercialUser
{
    public class GetEventsCreatedByCommercialUserQueryValidator : AbstractValidator<GetEventsCreatedByCommercialUserQuery>
    {
        public GetEventsCreatedByCommercialUserQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
