using EventManagerService.Application.Commands.UpdateUser;
using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.UpdateCommercialUser
{
    public class UpdateCommercialUserCommandHandler : IRequestHandler<UpdateCommercialUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCommercialUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCommercialUserCommand request, CancellationToken cancellationToken)
        {
            CommercialUser? user = _unitOfWork.CommercialUsers.Get(u => u.Id == request.Id);
            if (user is null)
            {
                throw new UserNotFoundException(request.Id);
            }
            user.Name = request.Name;
            user.PersonalAccount = request.PersonalAccount;
            user.CommercialEvents = (request.CommercialEventIds is not null) ? _unitOfWork.CommercialEvents.Where(u => request.CommercialEventIds.Contains(u.Id)) : null;
            _unitOfWork.SaveChanges();
        }
    }
}
