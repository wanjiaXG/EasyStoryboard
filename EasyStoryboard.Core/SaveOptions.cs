using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core
{
    public class SaveOptions
    {
        public readonly static SaveOptions Default = new SaveOptions();

        public bool Optimize { set; get; } = false;

        public string OuputDirectory { set; get; } = "dist";

        public string ResourceDirectory { set; get; } = "storyboard";

        public IRename Rename { set; get; }
    }
}
