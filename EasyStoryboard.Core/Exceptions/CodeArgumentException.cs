using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Exceptions
{
    public class CodeArgumentException : ArgumentException
    {
        public CodeArgumentException(string code) : base("无法解析代码:" + code) { }
    }
}
