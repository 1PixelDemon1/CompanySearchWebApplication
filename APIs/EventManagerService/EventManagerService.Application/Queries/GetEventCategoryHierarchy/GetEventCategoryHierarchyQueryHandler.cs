using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventCategoryHierarchy
{
    public class GetEventCategoryHierarchyQueryHandler : IRequestHandler<GetEventCategoryHierarchyQuery, IEnumerable<EventCategory>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEventCategoryHierarchyQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private void AddNewLayer(EventCategory category, ref HashSet<EventCategory> eventCategories)
        {
            if(category.ChildCategories is not null)
            {
                foreach (var eCat in category.ChildCategories) 
                {
                    eventCategories.Add(eCat);
                    AddNewLayer(eCat, ref eventCategories);
                }
            }
        }

        public async Task<IEnumerable<EventCategory>> Handle(GetEventCategoryHierarchyQuery request, CancellationToken cancellationToken)
        {
            EventCategory? baseCategory = _unitOfWork.Categories.Get(c => c.Id == request.EventCategoryId);
            if(baseCategory is null)
            {
                throw new CategoryNotFoundException(request.EventCategoryId);
            }
            HashSet<EventCategory> eventCategories = new() { baseCategory };
            AddNewLayer(baseCategory, ref eventCategories);
            return eventCategories.ToList();
        }
    }
}
