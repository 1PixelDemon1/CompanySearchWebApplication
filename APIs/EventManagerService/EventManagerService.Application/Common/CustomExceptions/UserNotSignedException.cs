using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Common.CustomExceptions
{
    public class UserNotSignedException : ApplicationException
    {
        public UserNotSignedException(int UserId, int EventId) : base($"User {UserId} not signed to event {EventId}") { }
    }
}
