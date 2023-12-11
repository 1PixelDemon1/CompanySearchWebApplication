using EventManagerService.Domain.Entities.BaseEntities;

namespace EventManagerService.Domain.Entities
{
    public class User : BaseUser
    {
        public enum Genders
        {
            MALE,
            FEMALE
        }
        public int Age { get; set; }
        public Genders Gender { get; set; }
        public int MyProperty { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        // Events the user signed in.
        public IEnumerable<BaseEvent>? SignedEvents { get; set; }
        // Events the user created.
        public IEnumerable<UserEvent>? UserEvents { get; set; }
    }
}
