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

namespace EventManagerService.Application.Queries.GetEventCategory
{
    public class GetEventCategoryQueryHandler : IRequestHandler<GetEventCategoryQuery, EventCategory>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEventCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EventCategory> Handle(GetEventCategoryQuery request, CancellationToken cancellationToken)
        {
            EventCategory? eventCategory = _unitOfWork.Categories.Get(c => c.Id == request.Id);
            if (eventCategory is null)
            {
                throw new CategoryNotFoundException(request.Id);
            }
            return eventCategory;
        }
    }
}
