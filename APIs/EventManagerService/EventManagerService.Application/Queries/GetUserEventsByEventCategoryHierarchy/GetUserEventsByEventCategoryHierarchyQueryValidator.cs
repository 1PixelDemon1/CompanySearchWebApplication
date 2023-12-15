using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetUserEventsByEventCategoryHierarchy
{
    public class GetUserEventsByEventCategoryHierarchyQueryValidator : AbstractValidator<GetUserEventsByEventCategoryHierarchyQuery>
    {
        public GetUserEventsByEventCategoryHierarchyQueryValidator()
        {
            RuleFor(query => query.BaseEventCategoryId).GreaterThan(0);
        }
    }
}
