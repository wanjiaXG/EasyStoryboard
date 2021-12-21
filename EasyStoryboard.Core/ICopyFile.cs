using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core
{
    public interface ICopyFile
    {
        string GetNewName(string baseDirectory, string relativePath, string sourcePath);
    }
}
