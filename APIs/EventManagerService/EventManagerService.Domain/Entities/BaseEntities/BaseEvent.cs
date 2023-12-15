namespace EventManagerService.Domain.Entities.BaseEntities
{
    public abstract class BaseEvent
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Location { get; set; }        
        public string Description { get; set; }

        public TimeSpan? EventDuration { get; set; }

        public GenderRules GenderRules { get; set; } = GenderRules.ALL;
        public DateTime? DeadLine { get; set; }
        public int? MinUsers { get; set; } = 0;
        public int? MaxUsers { get; set; } = -1;
        public int? MinAge { get; set; } = 0;
        public int? MaxAge { get; set; } = -1;

        public IEnumerable<EventCategory>? Categories { get; set; }
        public IEnumerable<User>? RegisteredUsers { get; set; }
    }
}
