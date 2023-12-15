using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using EventManagerService.Domain.Entities.BaseEntities;
using MediatR;

namespace EventManagerService.Application.Queries.GetUserEventsSigned
{
    public class GetUserEventsSignedQueryHandler : IRequestHandler<GetUserEventsSignedQuery, IEnumerable<UserEvent>?>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetUserEventsSignedQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserEvent>?> Handle(GetUserEventsSignedQuery request, CancellationToken cancellationToken)
        {
            User user = _unitOfWork.Users.Get(u => u.Id == request.UserId);
            if(user is null)
            {
                throw new UserNotFoundException(request.UserId);
            }
            return user.SignedEvents.Where(e => e is UserEvent).Select(e => e as UserEvent);
        }
    }
}
