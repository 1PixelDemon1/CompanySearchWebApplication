using EventManagerService.Domain.Entities.BaseEntities;
using EventManagerService.Domain.Entities;

namespace EventManagerService.API.Models
{
    public class CommercialEventDto
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public long? EventDuration { get; set; }

        public GenderRules GenderRules { get; set; }
        public DateTime? DeadLine { get; set; }
        public int? MinUsers { get; set; }
        public int? MaxUsers { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }

        public Decimal Price { get; set; }

        public IEnumerable<int>? CategoryIds { get; set; }
        public IEnumerable<int>? CommercialEventIds { get; set; }
    }
}
