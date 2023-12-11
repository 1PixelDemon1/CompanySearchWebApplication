using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventCategoriesFromCommercialEvent
{
    public class GetEventCategoriesFromCommercialEventQueryHandler : IRequestHandler<GetEventCategoriesFromCommercialEventQuery, IEnumerable<EventCategory>?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEventCategoriesFromCommercialEventQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<EventCategory>?> Handle(GetEventCategoriesFromCommercialEventQuery request, CancellationToken cancellationToken)
        {
            CommercialEvent commercialEvent = _unitOfWork.CommercialEvents.Get(e => e.Id == request.CommercialEventId);
            if (commercialEvent is null)
            {
                throw new EventNotFoundException(request.CommercialEventId);
            }
            return commercialEvent.Categories?.ToList();
        }
    }
}
