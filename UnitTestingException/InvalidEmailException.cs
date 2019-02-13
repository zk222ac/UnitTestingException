using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingException
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException()
        {

        }

        public InvalidEmailException(string email) : base($"{email}: Invalid Email address")
        {

        }
    }
}
