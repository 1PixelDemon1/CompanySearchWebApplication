using EventManagerService.Domain.Entities;
using MediatR;

namespace EventManagerService.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public User.Genders Gender { get; set; }
        // Ids of the user signed in events.
        public IEnumerable<int>? SignedEventIds { get; set; }
        // Ids of the user created events.
        public IEnumerable<int>? UserEventIds { get; set; }
    }
}
