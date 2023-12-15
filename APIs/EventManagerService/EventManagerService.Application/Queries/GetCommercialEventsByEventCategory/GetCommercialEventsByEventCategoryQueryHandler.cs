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

namespace EventManagerService.Application.Queries.GetCommercialEventsByEventCategory
{
    public class GetCommercialEventsByEventCategoryQueryHandler : IRequestHandler<GetCommercialEventsByEventCategoryQuery, IEnumerable<CommercialEvent>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCommercialEventsByEventCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CommercialEvent>> Handle(GetCommercialEventsByEventCategoryQuery request, CancellationToken cancellationToken)
        {
            EventCategory eventCategory = _unitOfWork.Categories.Get(c => c.Id == request.EventCategoryId);
            if(eventCategory is null) 
            {
                throw new CategoryNotFoundException(request.EventCategoryId);    
            }
            
            return eventCategory.Events.Where(e => e is CommercialEvent).Select(e => e as CommercialEvent).ToList();
        }
    }
}
