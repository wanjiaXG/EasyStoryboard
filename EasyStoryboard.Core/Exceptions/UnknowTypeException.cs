using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Exceptions
{
    public class UnknowTypeException : ArgumentException
    {
        public UnknowTypeException(string type) : base($"'{type}' is unknow type.") { } 
    }
}
