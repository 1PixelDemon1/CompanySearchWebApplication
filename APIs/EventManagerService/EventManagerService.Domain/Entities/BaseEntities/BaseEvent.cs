namespace EventManagerService.Domain.Entities.BaseEntities
{
    public abstract class BaseEvent
    {
        public int Id { get; set; }
        public BaseUser Creator;
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Location { get; set; }        
        public string Description { get; set; }

        public TimeSpan? EventDuration { get; set; }

        public GenderRules GenderRules { get; set; } = GenderRules.ALL;
        public DateTime? DeadLine { get; set; }
        public int? MinUsers { get; set; }
        public int? MaxUsers { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }

        public IEnumerable<EventCategory>? Categories { get; set; }
        public IEnumerable<User>? RegisteredUsers { get; set; }
    }
}
