using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core
{
    public class StoryboardHeaderAttribute : Attribute
    {
        public string Header { private set; get; }

        public StoryboardHeaderAttribute(string header)
        {
            Header = header;
        }
    }
}
