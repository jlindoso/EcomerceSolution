using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidObjectException: Exception
    {

        public InvalidObjectException(){}
        public InvalidObjectException(string message) : base(message) { }
    }
}
