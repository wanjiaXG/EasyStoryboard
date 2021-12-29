using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Exceptions
{
    public class NotNullException : ArgumentException
    {
        public NotNullException() : base("Argument can't be null.") { }
    }
}
