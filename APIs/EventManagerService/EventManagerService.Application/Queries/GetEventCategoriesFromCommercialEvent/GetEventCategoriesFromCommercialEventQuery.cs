using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventCategoriesFromCommercialEvent
{
    public class GetEventCategoriesFromCommercialEventQuery : IRequest<IEnumerable<EventCategory>?>
    {
        public int CommercialEventId { get; set; }
    }
}
