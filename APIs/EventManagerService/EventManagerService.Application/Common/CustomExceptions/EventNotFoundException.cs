using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Common.CustomExceptions
{
    public class EventNotFoundException : ApplicationException
    {
        public EventNotFoundException(int id) : base($"Unable to find event with given id: {id}") { }
    }
}
