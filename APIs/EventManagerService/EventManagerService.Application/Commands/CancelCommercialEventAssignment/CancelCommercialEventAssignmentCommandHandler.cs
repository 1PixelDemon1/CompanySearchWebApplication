using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.CancelCommercialEventAssignment
{
    public class CancelCommercialEventAssignmentCommandHandler : IRequestHandler<CancelCommercialEventAssignmentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CancelCommercialEventAssignmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CancelCommercialEventAssignmentCommand request, CancellationToken cancellationToken)
        {
            CommercialEvent commercialEvent = _unitOfWork.CommercialEvents.Get(e => e.Id == request.EventId);
            User user = _unitOfWork.Users.Get(u => u.Id == request.UserId);
            if (!commercialEvent.RegisteredUsers.Contains(user))
            {
                throw new UserNotSignedException(request.UserId, request.EventId);
            }
            (commercialEvent.RegisteredUsers as ICollection<User>).Remove(user);
            _unitOfWork.SaveChanges();
        }
    }
}
