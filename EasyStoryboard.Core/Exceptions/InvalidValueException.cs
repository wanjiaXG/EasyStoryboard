using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Exceptions
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException(string msg): base(msg){ }
    }
}
