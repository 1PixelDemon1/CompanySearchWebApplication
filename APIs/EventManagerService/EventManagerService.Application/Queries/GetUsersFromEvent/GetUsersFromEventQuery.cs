using EventManagerService.Domain.Entities;
using MediatR;

namespace EventManagerService.Application.Queries.GetUsersFromEvent
{
    public class GetUsersFromEventQuery : IRequest<IEnumerable<User>?>
    {
        public int Id { get; set; }
    }
}
