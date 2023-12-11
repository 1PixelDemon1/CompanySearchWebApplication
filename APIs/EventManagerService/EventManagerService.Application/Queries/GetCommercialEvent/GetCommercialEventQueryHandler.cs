using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetCommercialEvent
{
    public class GetCommercialEventQueryHandler : IRequestHandler<GetCommercialEventQuery, CommercialEvent>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetCommercialEventQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CommercialEvent> Handle(GetCommercialEventQuery request, CancellationToken cancellationToken)
        {
            CommercialEvent? commercialEvent = _unitOfWork.CommercialEvents.Get(u => u.Id == request.Id);
            if (commercialEvent is null)
            {
                throw new EventNotFoundException(request.Id);
            }
            return commercialEvent;
        }
    }
}
