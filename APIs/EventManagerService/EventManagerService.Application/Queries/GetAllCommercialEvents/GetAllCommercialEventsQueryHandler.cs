using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;

namespace EventManagerService.Application.Queries.GetAllCommercialEvents
{
    public class GetAllCommercialEventsQueryHandler : IRequestHandler<GetAllCommercialEventsQuery, IEnumerable<CommercialEvent>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllCommercialEventsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CommercialEvent>> Handle(GetAllCommercialEventsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.CommercialEvents.Where(e => true);
        }
    }
}
