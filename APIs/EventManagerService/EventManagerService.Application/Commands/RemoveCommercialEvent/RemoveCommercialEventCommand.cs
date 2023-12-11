using MediatR;

namespace EventManagerService.Application.Commands.RemoveCommercialEvent
{
    public class RemoveCommercialEventCommand : IRequest
    {
        public int Id { get; set; }
    }
}
