using EventManagerService.Domain.Entities.BaseEntities;

namespace EventManagerService.Domain.Entities
{
    public class CommercialUser : BaseUser
    {
        public string? PersonalAccount { get; set; }
        public IEnumerable<CommercialEvent>? CommercialEvents { get; set; }
    }
}
