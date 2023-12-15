using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetAllCommercialUsers
{
    public class GetAllCommercialUsersQueryHandler : IRequestHandler<GetAllCommercialUsersQuery, IEnumerable<CommercialUser>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCommercialUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CommercialUser>> Handle(GetAllCommercialUsersQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.CommercialUsers.Where(u => true);
        }
    }
}
