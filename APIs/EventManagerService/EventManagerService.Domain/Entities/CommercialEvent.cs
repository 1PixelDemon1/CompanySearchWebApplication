using EventManagerService.Domain.Entities.BaseEntities;

namespace EventManagerService.Domain.Entities
{
    public class CommercialEvent : BaseEvent
    {
        public CommercialUser Creator { get; set; }
        public Decimal Price { get; set; }
        // Links to other commercial events.
        public IEnumerable<CommercialEvent>? CommercialEvents { get; set; }
    }
}
