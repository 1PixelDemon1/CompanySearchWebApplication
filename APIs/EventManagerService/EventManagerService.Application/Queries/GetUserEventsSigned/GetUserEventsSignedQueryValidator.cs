﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetUserEventsSigned
{
    public class GetUserEventsSignedQueryValidator : AbstractValidator<GetUserEventsSignedQuery>
    {
        public GetUserEventsSignedQueryValidator()
        {
            RuleFor(query => query.UserId).GreaterThan(0);
        }
    }
}
