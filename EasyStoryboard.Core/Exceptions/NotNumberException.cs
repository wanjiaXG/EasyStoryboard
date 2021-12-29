using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Exceptions
{
    public class NotNumberException : ArgumentException
    {
        public NotNumberException(string value) : base($"Value: '{value}' is not a number.") { }
    }
}
