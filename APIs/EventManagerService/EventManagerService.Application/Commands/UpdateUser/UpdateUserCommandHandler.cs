using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;

namespace EventManagerService.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User? user = _unitOfWork.Users.Get(u => u.Id == request.Id);
            if(user is null)
            {
                throw new UserNotFoundException(request.Id);
            }
            user.PhoneNumber = request.PhoneNumber;
            user.Name = request.Name;
            user.Email = request.Email;
            user.UserEvents = (request.UserEventIds is not null) ? _unitOfWork.UserEvents.Where(u => request.UserEventIds.Contains(u.Id)) : null;
            user.SignedEvents = (request.SignedEventIds is not null) ? _unitOfWork.UserEvents.Where(u => request.SignedEventIds.Contains(u.Id)) : null;
            _unitOfWork.SaveChanges();
        }
    }
}
