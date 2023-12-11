using EventManagerService.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Domain.Entities
{
    public class EventCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<BaseEvent>? Events { get; set; }
        public EventCategory? ParentCategory{ get; set; }
    }
}
