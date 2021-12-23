using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core
{
    public class Options
    {
        public bool Optimize { set; get; } = false;

        public string OuputDirectory { set; get; } = "dist";

        public ICopyFile CopyFile { set; get; } = new CopyFile();
    }
}
