using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Common.CustomExceptions
{
    public class UserNotMetRequirementsException : ApplicationException
    {
        public UserNotMetRequirementsException(string criterea) : base($"Unable to assign user due to \"{criterea}\" criterea.") { }
    }
}
