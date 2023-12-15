﻿using EventManagerService.Domain.Entities;
using EventManagerService.Domain.Entities.BaseEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetUserEventsByEventCategory
{
    public class GetUserEventsByEventCategoryQuery : IRequest<IEnumerable<UserEvent>>
    {
        public int EventCategoryId { get; set; }
    }
}
