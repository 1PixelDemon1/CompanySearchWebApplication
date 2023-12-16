using EventManagerService.Domain.Entities.BaseEntities;

namespace EventManagerService.Domain.Entities
{
    public class UserEvent : BaseEvent
    {
        public User Creator { get; set; }
        public IEnumerable<UserEvent>? UserEvents { get; set; }
        public IEnumerable<CommercialEvent>? CommercialEvents { get; set; }
    }
}
