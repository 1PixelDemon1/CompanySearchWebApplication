using EventManagerService.Domain.Entities.BaseEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventsByEventCategory
{
    public class GetEventsByEventCategoryQuery : IRequest<IEnumerable<BaseEvent>>
    {
        public int EventCategoryId { get; set; }
    }
}
