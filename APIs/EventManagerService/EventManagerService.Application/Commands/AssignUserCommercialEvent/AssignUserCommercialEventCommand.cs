using MediatR;

namespace EventManagerService.Application.Commands.AssignUser
{
    public class AssignUserCommercialEventCommand : IRequest
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}
