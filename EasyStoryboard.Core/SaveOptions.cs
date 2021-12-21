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

        public ICopyFile CopyFile { set; get; } = new CopyFileImpl();

        private class CopyFileImpl : ICopyFile
        {
            public string GetNewName(string baseDirectory, string relativePath, string sourcePath)
            {
                string newPath = baseDirectory + "\\" + relativePath;
                return relativePath;
            }
        }
    }
}
