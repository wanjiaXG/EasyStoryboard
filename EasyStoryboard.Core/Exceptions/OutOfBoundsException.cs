using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Exceptions
{
    public class OutOfBoundsException : ArgumentException
    {
        public OutOfBoundsException(object value, object min, object max): base($"Value '{value}' out of bounds, the valid range is {min}-{max}") { }

    }
}
