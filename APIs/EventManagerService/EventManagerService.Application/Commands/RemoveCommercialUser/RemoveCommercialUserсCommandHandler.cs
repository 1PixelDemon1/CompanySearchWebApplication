using EventManagerService.Application.Commands.RemoveUser;
using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.RemoveCommercialUser
{
    public class RemoveCommercialUserCommandHandler : IRequestHandler<RemoveCommercialUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCommercialUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveCommercialUserCommand request, CancellationToken cancellationToken)
        {
            CommercialUser user = _unitOfWork.CommercialUsers.Get(u => u.Id == request.Id);
            if (user is null)
            {
                throw new UserNotFoundException(request.Id);
            }
            _unitOfWork.CommercialUsers.Remove(user);
            _unitOfWork.SaveChanges();
        }
    }
}
