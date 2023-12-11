using EventManagerService.Domain;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.UpdateCommercialEvent
{
    public class UpdateCommercialEventCommand : IRequest
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public TimeSpan? EventDuration { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public GenderRules GenderRules { get; set; } = GenderRules.ALL;
        public DateTime? DeadLine { get; set; }
        public int? MinUsers { get; set; }
        public int? MaxUsers { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }

        // Participants.
        public IEnumerable<int>? UserIds { get; set; }
        public IEnumerable<int>? CategoryIds { get; set; }
        public IEnumerable<int>? CommercialEventIds { get; set; }
        public Decimal Price { get; set; }

    }
}
