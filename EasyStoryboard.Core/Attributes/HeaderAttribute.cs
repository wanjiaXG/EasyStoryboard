using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Attributes
{
    public class HeaderAttribute : Attribute
    {
        public string Header { private set; get; }

        public HeaderAttribute(string header)
        {
            Header = header;
        }
    }
}
