using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;

namespace EventManagerService.Application.Queries.GetAllUserEvents
{
    public class GetAllUserEventsQueryHandler : IRequestHandler<GetAllUserEventsQuery, IEnumerable<UserEvent>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllUserEventsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserEvent>> Handle(GetAllUserEventsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.UserEvents.Where(e => true);
        }
    }
}
