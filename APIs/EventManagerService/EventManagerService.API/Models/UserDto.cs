using static EventManagerService.Domain.Entities.User;

namespace EventManagerService.API.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Genders Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
