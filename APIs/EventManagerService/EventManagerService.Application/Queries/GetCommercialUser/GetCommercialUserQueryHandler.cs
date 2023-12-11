using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Application.Queries.GetUser;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetCommercialUser
{
    public class GetCommercialUserQueryHandler : IRequestHandler<GetCommercialUserQuery, CommercialUser>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCommercialUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CommercialUser> Handle(GetCommercialUserQuery request, CancellationToken cancellationToken)
        {
            CommercialUser? commercialUser = _unitOfWork.CommercialUsers.Get(u => u.Id == request.Id);
            if (commercialUser is null)
            {
                throw new UserNotFoundException(request.Id);
            }
            return commercialUser;
        }
    }
}
