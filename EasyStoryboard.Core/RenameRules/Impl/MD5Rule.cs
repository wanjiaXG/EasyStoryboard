using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.RenameRules
{
    public class MD5Rule : ICopyRule
    {
        public string GetNewName(string baseDir, string resDirName, string filePath, string suffix)
        {
            string md5 = Commons.CommonUtil.GetFileMD5Hash(filePath);
            string newPath = baseDir + resDirName + "\\" + md5 + suffix;
            if (!File.Exists(newPath))
            {
                File.Copy(filePath, newPath);
            }
            return resDirName + "\\" + md5 + suffix;
        }
    }
}
