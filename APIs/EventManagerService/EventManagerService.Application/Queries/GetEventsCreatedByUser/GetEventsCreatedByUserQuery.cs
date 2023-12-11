using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetEventsCreatedByUser
{
    public class GetEventsCreatedByUserQuery : IRequest<IEnumerable<UserEvent>>
    {
        public int Id { get; set; }
    }
}
