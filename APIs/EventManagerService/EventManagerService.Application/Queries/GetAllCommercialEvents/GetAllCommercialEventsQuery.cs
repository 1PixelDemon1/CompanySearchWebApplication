using EventManagerService.Domain.Entities;
using MediatR;

namespace EventManagerService.Application.Queries.GetAllCommercialEvents
{
    public class GetAllCommercialEventsQuery : IRequest<IEnumerable<CommercialEvent>> {}
}
