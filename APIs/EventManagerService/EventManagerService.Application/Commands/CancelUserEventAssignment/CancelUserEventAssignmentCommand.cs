using MediatR;

namespace EventManagerService.Application.Commands.CancelUserEventAssignment
{
    public class CancelUserEventAssignmentCommand : IRequest
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}
