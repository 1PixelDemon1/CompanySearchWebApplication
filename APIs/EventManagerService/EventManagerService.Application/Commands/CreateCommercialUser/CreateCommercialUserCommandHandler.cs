using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.CreateCommercialUser
{
    public class CreateCommercialUserCommandHandler : IRequestHandler<CreateCommercialUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommercialUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateCommercialUserCommand request, CancellationToken cancellationToken)
        {
            CommercialUser commercialUser = new()
            {
                Name = request.Name,
                PersonalAccount = request.PersonalAccount
            };

            await _unitOfWork.CommercialUsers.AddAsync(commercialUser);
            _unitOfWork.SaveChanges();
        }
    }
}
