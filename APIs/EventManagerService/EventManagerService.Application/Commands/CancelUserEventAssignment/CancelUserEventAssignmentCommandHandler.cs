using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;

namespace EventManagerService.Application.Commands.CancelUserEventAssignment
{
    public class CancelUserEventAssignmentCommandHandler : IRequestHandler<CancelUserEventAssignmentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CancelUserEventAssignmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CancelUserEventAssignmentCommand request, CancellationToken cancellationToken)
        {
            UserEvent userEvent = _unitOfWork.UserEvents.Get(e => e.Id == request.EventId);
            User user = _unitOfWork.Users.Get(u => u.Id == request.UserId);
            if(!userEvent.RegisteredUsers.Contains(user))
            {
                throw new UserNotSignedException(request.UserId, request.EventId);
            }
            (userEvent.RegisteredUsers as ICollection<User>).Remove(user);
            _unitOfWork.SaveChanges();
        }
    }
}
