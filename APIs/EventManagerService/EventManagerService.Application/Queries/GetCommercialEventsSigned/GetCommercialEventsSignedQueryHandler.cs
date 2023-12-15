using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;

namespace EventManagerService.Application.Queries.GetCommercialEventsSigned
{
    public class GetCommercialEventsSignedQueryHandler : IRequestHandler<GetCommercialEventsSignedQuery, IEnumerable<CommercialEvent>?>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetCommercialEventsSignedQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CommercialEvent>?> Handle(GetCommercialEventsSignedQuery request, CancellationToken cancellationToken)
        {
            User user = _unitOfWork.Users.Get(u => u.Id == request.UserId);
            if (user is null)
            {
                throw new UserNotFoundException(request.UserId);
            }
            return user.SignedEvents.Where(e => e is CommercialEvent).Select(e => e as CommercialEvent);
        }
    }
}
