using EventManagerService.Domain.Entities;
using MediatR;

namespace EventManagerService.Application.Commands.CreateCommercialUser
{
    public class CreateCommercialUserCommand : IRequest
    {
        public string Name { get; set; }
        public string? PersonalAccount { get; set; }
    }
}
