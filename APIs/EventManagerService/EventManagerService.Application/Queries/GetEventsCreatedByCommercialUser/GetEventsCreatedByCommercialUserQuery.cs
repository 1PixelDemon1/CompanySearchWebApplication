using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventsCreatedByCommercialUser
{
    public class GetEventsCreatedByCommercialUserQuery : IRequest<IEnumerable<CommercialEvent>>
    {
        public int Id { get; set; }
    }
}
