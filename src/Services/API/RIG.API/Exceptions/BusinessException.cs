using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RIG.API.Exceptions
{
    // Handling the Client Errors
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {

        }
    }
}
