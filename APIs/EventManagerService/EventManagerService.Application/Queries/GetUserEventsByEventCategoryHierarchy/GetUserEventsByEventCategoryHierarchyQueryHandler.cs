using EventManagerService.Application.Interfaces;
using EventManagerService.Application.Queries.GetEventCategoryHierarchy;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetUserEventsByEventCategoryHierarchy
{
    public class GetUserEventsByEventCategoryHierarchyQueryHandler : IRequestHandler<GetUserEventsByEventCategoryHierarchyQuery, IEnumerable<UserEvent>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public GetUserEventsByEventCategoryHierarchyQueryHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;

        }

        public async Task<IEnumerable<UserEvent>> Handle(GetUserEventsByEventCategoryHierarchyQuery request, CancellationToken cancellationToken)
        {
            var command = new GetEventCategoryHierarchyQuery
            {
                EventCategoryId = request.BaseEventCategoryId
            };
            IEnumerable<int> eventCategoriesIds = (await _mediator.Send(command)).Select(ec => ec.Id);
            IEnumerable<UserEvent>? userEvents = _unitOfWork.UserEvents.Where(e => e.Categories.Any(cat => eventCategoriesIds.Contains(cat.Id)));
            return userEvents;
        }
    }
}
