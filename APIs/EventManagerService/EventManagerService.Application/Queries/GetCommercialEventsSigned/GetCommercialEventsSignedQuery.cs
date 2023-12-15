using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetCommercialEventsSigned
{
    public class GetCommercialEventsSignedQuery : IRequest<IEnumerable<CommercialEvent>?>
    {
        public int UserId { get; set; }
    }
}
