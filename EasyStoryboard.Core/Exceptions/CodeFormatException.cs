using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Exceptions
{
    public class CodeFormatException : ArgumentException
    {
        public CodeFormatException(string code) : base($"'{code}' is invalid code.") { }
    }
}
