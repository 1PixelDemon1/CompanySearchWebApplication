using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventCategory
{
    public class GetEventCategoryQuery : IRequest<EventCategory>
    {
        public int Id { get; set; }
    }
}
