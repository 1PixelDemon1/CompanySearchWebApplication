using EventManagerService.Domain.Entities;

namespace EventManagerService.API.Models
{
    public class UserEventDto
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public long? EventDuration { get; set; }

        public GenderRules GenderRules { get; set; }
        public DateTime? DeadLine { get; set; }
        public int? MinUsers { get; set; } = 0;
        public int? MaxUsers { get; set; } = -1;
        public int? MinAge { get; set; } = 0;
        public int? MaxAge { get; set; } = -1;


        public IEnumerable<int>? CategoryIds { get; set; }
        public IEnumerable<int>? UserEventIds { get; set; }
        public IEnumerable<int>? CommercialEventIds { get; set; }
    }
}
