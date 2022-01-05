using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Exceptions
{
    public class NotNumberException : ArgumentException
    {
        public NotNumberException(string value) : base($"Value: '{value}' is not a number or type mismatch.") { }
        public NotNumberException(string value, Type type) : base($"Value: '{value}' is not a number or type is not {type.Name}.") { }
    }
}
