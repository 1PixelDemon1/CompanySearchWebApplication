using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventsCreatedByUser
{
    public class GetEventsCreatedByUserQueryHandler : IRequestHandler<GetEventsCreatedByUserQuery, IEnumerable<UserEvent>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEventsCreatedByUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<UserEvent>?> Handle(GetEventsCreatedByUserQuery request, CancellationToken cancellationToken)
        {
            User user = _unitOfWork.Users.Get(u => u.Id == request.Id);
            if (user is null)
            {
                throw new UserNotFoundException(request.Id);
            }
            return user.UserEvents?.ToList();
        }
    }
}
