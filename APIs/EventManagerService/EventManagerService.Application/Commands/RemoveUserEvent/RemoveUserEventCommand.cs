using MediatR;

namespace EventManagerService.Application.Commands.RemoveUserEvent
{
    public class RemoveUserEventCommand : IRequest
    {
        public int Id { get; set; }
    }
}
