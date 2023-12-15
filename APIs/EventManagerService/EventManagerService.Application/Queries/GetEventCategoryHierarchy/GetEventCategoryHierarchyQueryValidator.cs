using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventCategoryHierarchy
{
    public class GetEventCategoryHierarchyQueryValidator : AbstractValidator<GetEventCategoryHierarchyQuery>
    {
        public GetEventCategoryHierarchyQueryValidator()
        {
            RuleFor(query => query.EventCategoryId).GreaterThan(0);
        }
    }
}
