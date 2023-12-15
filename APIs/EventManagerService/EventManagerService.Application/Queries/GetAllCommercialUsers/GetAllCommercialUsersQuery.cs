using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetAllCommercialUsers
{
    public class GetAllCommercialUsersQuery : IRequest<IEnumerable<CommercialUser>>
    {
    }
}
