using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Core.Exceptions
{
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException() : base("Invalid Username Message"){ }

    }
}
