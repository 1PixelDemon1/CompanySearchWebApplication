using FluentValidation;

namespace EventManagerService.Application.Queries.GetCommercialEventsByEventCategory
{
    public class GetCommercialEventsByEventCategoryQueryValidator : AbstractValidator<GetCommercialEventsByEventCategoryQuery>
    {
        public GetCommercialEventsByEventCategoryQueryValidator()
        {
            RuleFor(query => query.EventCategoryId).GreaterThan(0);
        }
    }
}
