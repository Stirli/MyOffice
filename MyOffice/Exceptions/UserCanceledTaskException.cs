using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOffice.Exceptions
{
    class UserCanceledTaskException : Exception
    {
        public UserCanceledTaskException()
        {

        }

        public UserCanceledTaskException(string message) : base(message)
        {

        }
    }
}
