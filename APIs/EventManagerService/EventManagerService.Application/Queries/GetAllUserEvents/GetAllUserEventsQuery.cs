using EventManagerService.Domain.Entities;
using MediatR;

namespace EventManagerService.Application.Queries.GetAllUserEvents
{
    public class GetAllUserEventsQuery : IRequest<IEnumerable<UserEvent>> {}
}
