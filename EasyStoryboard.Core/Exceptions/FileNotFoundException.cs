using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Exceptions
{
    public class FileNotFoundException : IOException
    {
        public FileNotFoundException(string fileName) : base($"未找到名为'{fileName}'的文件", -1) { }

    }
}
