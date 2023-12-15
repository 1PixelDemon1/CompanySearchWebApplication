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
    public class GetUsersFromCommercialEventQueryHandler : IRequestHandler<GetUsersFromCommercialEventQuery, IEnumerable<User>?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsersFromCommercialEventQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>?> Handle(GetUsersFromCommercialEventQuery request, CancellationToken cancellationToken)
        {
            CommercialEvent commercialEvent = _unitOfWork.CommercialEvents.Get(e => e.Id == request.Id);
            if(commercialEvent is null)
            {
                throw new EventNotFoundException(request.Id);
            }
            return commercialEvent.RegisteredUsers?.ToList();
        }
    }
}
