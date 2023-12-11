using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetUsersFromEvent
{
    public class GetUsersFromEventQueryHandler : IRequestHandler<GetUsersFromEventQuery, IEnumerable<User>?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsersFromEventQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>?> Handle(GetUsersFromEventQuery request, CancellationToken cancellationToken)
        {
            UserEvent userEvent = _unitOfWork.UserEvents.Get(e => e.Id == request.Id);
            if(userEvent is null)
            {
                throw new EventNotFoundException(request.Id);
            }
            return userEvent.RegisteredUsers?.ToList();
        }
    }
}
