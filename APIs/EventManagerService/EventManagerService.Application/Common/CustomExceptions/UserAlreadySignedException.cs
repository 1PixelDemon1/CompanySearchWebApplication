using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Common.CustomExceptions
{
    public class UserAlreadySignedException : ApplicationException
    {
        public UserAlreadySignedException(int UserId, int EventId) : base($"User {UserId} already signed to event {EventId}") { }
    }
}
