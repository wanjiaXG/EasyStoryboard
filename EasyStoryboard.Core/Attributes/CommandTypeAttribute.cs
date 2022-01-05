using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Attributes
{
    public class CommandTypeAttribute : Attribute
    {
        public string Header { private set; get; }

        public Type Type { set; get; }

        public CommandTypeAttribute(string header)
        {
            Header = header;
        }
    }
}
