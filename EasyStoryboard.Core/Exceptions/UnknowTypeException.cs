using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Exceptions
{
    public class UnknowTypeException : ArgumentException
    {
        public UnknowTypeException(string value) : base($"Value '{value}' is unknow type.") { }
        public UnknowTypeException(string value, Type type) : base($"Value '{value}' is not {type.Name}.") { }
    }
}
