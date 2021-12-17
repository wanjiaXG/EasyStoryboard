using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.RenameRules
{
    public interface ICopyRule
    {
        string GetNewName(string baseDir, string resDirName, string filePath, string suffix);
    }
}
