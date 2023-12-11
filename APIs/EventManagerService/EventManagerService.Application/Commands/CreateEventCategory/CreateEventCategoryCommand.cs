using EventManagerService.Domain.Entities.BaseEntities;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.CreateEventCategory
{
    public class CreateEventCategoryCommand : IRequest
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
