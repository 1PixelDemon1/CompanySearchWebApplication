using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetCommercialEvent
{
    public class GetCommercialEventQuery : IRequest<CommercialEvent>
    {
        public int Id { get; set; }
    }
}
