using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;

namespace EventManagerService.Application.Commands.RemoveUser
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            User user = _unitOfWork.Users.Get(u => u.Id == request.Id);
            if (user is null)
            {
                throw new UserNotFoundException(request.Id);
            }
            _unitOfWork.Users.Remove(user);
            _unitOfWork.SaveChanges();
        }
    }
}
