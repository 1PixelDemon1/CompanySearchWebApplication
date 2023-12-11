using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;

namespace EventManagerService.Application.Commands.RemoveUserEvent
{
    public class RemoveUserEventCommandHandler : IRequestHandler<RemoveUserEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveUserEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveUserEventCommand request, CancellationToken cancellationToken)
        {
            UserEvent userEvent = _unitOfWork.UserEvents.Get(u => u.Id == request.Id);
            if (userEvent is null)
            {
                throw new EventNotFoundException(request.Id);
            }

            _unitOfWork.UserEvents.Remove(userEvent);
            _unitOfWork.SaveChanges();
        }
    }
}
