using EventManagerService.Application.Interfaces;
using EventManagerService.Application.Queries.GetEventCategoryHierarchy;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetCommercialEventsByEventCategoryHierarchy
{
    public class GetCommercialEventsByEventCategoryHierarchyQueryHandler : IRequestHandler<GetCommercialEventsByEventCategoryHierarchyQuery, IEnumerable<CommercialEvent>?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public GetCommercialEventsByEventCategoryHierarchyQueryHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<IEnumerable<CommercialEvent>?> Handle(GetCommercialEventsByEventCategoryHierarchyQuery request, CancellationToken cancellationToken)
        {
            var command = new GetEventCategoryHierarchyQuery
            {
                EventCategoryId = request.BaseEventCategoryId
            };
            IEnumerable<int> eventCategoriesIds = (await _mediator.Send(command)).Select(ec => ec.Id);
            IEnumerable<CommercialEvent>? commercialEvents = _unitOfWork.CommercialEvents.Where(ce => ce.Categories.Any(cat => eventCategoriesIds.Contains(cat.Id)));
            return commercialEvents;

        }
    }
}
