using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventCategoriesFromUserEvent
{
    public class GetEventCategoriesFromUserEventQueryHandler : IRequestHandler<GetEventCategoriesFromUserEventQuery, IEnumerable<EventCategory>?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEventCategoriesFromUserEventQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<EventCategory>?> Handle(GetEventCategoriesFromUserEventQuery request, CancellationToken cancellationToken)
        {
            UserEvent? userEvent = _unitOfWork.UserEvents.Get(e => e.Id == request.UserEventId);
            if (userEvent is null) 
            {
                throw new EventNotFoundException(request.UserEventId);
            }
            return userEvent.Categories?.ToList();
        }
    }
}
