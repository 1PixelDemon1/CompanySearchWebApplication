using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Common.CustomExceptions
{
    public class UserNotFoundException : ApplicationException
    {
        public UserNotFoundException(int id) : base($"Unable to find user with given id: {id}") { }
    }
}
