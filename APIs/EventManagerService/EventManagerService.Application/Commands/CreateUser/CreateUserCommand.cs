using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public User.Genders Gender { get; set; }
    }
}
