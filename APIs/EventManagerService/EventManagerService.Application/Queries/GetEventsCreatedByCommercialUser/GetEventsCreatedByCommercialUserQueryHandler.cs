using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;

namespace EventManagerService.Application.Queries.GetEventsCreatedByCommercialUser
{
    public class GetEventsCreatedByCommercialUserQueryHandler : IRequestHandler<GetEventsCreatedByCommercialUserQuery, IEnumerable<CommercialEvent>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEventsCreatedByCommercialUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CommercialEvent>?> Handle(GetEventsCreatedByCommercialUserQuery request, CancellationToken cancellationToken)
        {
            CommercialUser commercialUser = _unitOfWork.CommercialUsers.Get(u => u.Id == request.Id);
            if (commercialUser is null)
            {
                throw new UserNotFoundException(request.Id);
            }
            return commercialUser.CommercialEvents?.ToList();
        }
    }
}
