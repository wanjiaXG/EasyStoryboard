using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core
{
    public class OsbBuilder
    {
        public bool Optimize { set; get; }

        public IRename Rename { set; get; }

        public string OutputDirectory { set; get; }

        public string BaseDirectory { set; get; }

        public string OsbName { set; get; }

        public string Build()
        {
            return "";
        }

    }
}
