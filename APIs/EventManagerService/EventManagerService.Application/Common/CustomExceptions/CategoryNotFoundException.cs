using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Common.CustomExceptions
{
    public class CategoryNotFoundException : ApplicationException
    {
        public CategoryNotFoundException(int id) : base($"Unable to find category with given id: {id}") { }
    }
}
