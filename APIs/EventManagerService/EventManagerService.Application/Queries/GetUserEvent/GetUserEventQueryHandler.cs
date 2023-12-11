using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetUserEvent
{
    public class GetUserEventQueryHandler : IRequestHandler<GetUserEventQuery, UserEvent>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetUserEventQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserEvent> Handle(GetUserEventQuery request, CancellationToken cancellationToken)
        {
            UserEvent? userEvent = _unitOfWork.UserEvents.Get(u => u.Id == request.Id);
            if (userEvent is null)
            {
                throw new EventNotFoundException(request.Id);
            }
            return userEvent;
        }
    }
}
