using EventManagerService.Domain.Entities;
using MediatR;

namespace EventManagerService.Application.Queries.GetUsersFromEvent
{
    public class GetUsersFromCommercialEventQuery : IRequest<IEnumerable<User>?>
    {
        public int Id { get; set; }
    }
}
