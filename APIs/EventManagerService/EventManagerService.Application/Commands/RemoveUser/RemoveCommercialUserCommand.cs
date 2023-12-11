using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.RemoveUser
{
    public class RemoveCommercialUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
