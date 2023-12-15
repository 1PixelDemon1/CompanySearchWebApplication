using MediatR;

namespace EventManagerService.Application.Commands.AssignUserCommercialEvent
{
    public class AssignUserCommercialEventCommand : IRequest
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}
