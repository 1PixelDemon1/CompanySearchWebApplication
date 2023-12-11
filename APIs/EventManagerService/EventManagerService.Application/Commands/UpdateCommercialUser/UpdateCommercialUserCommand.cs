using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.UpdateCommercialUser
{
    public class UpdateCommercialUserCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PersonalAccount { get; set; }
        // Ids of the user created events.
        public IEnumerable<int>? CommercialEventIds { get; set; }
    }
}
