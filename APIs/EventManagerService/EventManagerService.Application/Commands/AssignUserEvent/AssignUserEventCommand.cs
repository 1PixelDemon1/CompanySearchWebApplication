using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.AssignUserEvent
{
    public class AssignUserEventCommand : IRequest
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}
