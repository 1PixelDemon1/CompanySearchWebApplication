﻿using FluentValidation;

namespace EventManagerService.Application.Queries.GetUserEventsByEventCategory
{
    public class GetUserEventsByEventCategoryQueryValidator : AbstractValidator<GetUserEventsByEventCategoryQuery>
    {
        public GetUserEventsByEventCategoryQueryValidator()
        {
            RuleFor(query => query.EventCategoryId).GreaterThan(0);
        }
    }
}
