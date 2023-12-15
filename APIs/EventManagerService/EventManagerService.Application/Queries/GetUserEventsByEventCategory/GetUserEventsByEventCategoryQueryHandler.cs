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

namespace EventManagerService.Application.Queries.GetUserEventsByEventCategory
{
    public class GetUserEventsByEventCategoryQueryHandler : IRequestHandler<GetUserEventsByEventCategoryQuery, IEnumerable<UserEvent>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserEventsByEventCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserEvent>> Handle(GetUserEventsByEventCategoryQuery request, CancellationToken cancellationToken)
        {
            EventCategory eventCategory = _unitOfWork.Categories.Get(c => c.Id == request.EventCategoryId);
            if(eventCategory is null) 
            {
                throw new CategoryNotFoundException(request.EventCategoryId);    
            }
            
            return eventCategory.Events.Where(e => e is UserEvent).Select(e => e as UserEvent).ToList();
        }
    }
}
