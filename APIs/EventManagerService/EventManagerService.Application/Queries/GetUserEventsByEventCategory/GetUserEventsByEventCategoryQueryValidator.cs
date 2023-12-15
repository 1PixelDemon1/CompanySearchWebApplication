using FluentValidation;

namespace EventManagerService.Application.Queries.GetUserEventsByEventCategory
{
    public class GetUserEventsByEventCategoryQueryValidator : AbstractValidator<GetUserEventsByEventCategoryQuery>
    {
        public GetUserEventsByEventCategoryQueryValidator()
        {
            RuleFor(command => command.EventCategoryId).GreaterThan(0);
        }
    }
}
