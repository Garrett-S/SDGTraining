using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProTraining.Dal.CustomExceptions
{
    public class DBRemoveException: System.Exception
    {
        public DBRemoveException()
        {
        }

        public DBRemoveException(string message)
            : base(message)
        {
        }

        public DBRemoveException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
