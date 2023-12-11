using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using EventManagerService.Domain.Entities.BaseEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventsByEventCategory
{
    public class GetEventsByEventCategoryQueryHandler : IRequestHandler<GetEventsByEventCategoryQuery, IEnumerable<BaseEvent>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEventsByEventCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BaseEvent>> Handle(GetEventsByEventCategoryQuery request, CancellationToken cancellationToken)
        {
            EventCategory eventCategory = _unitOfWork.Categories.Get(c => c.Id == request.EventCategoryId);
            if(eventCategory is null) 
            {
                throw new CategoryNotFoundException(request.EventCategoryId);    
            }
            return eventCategory.Events?.ToList();
        }
    }
}
