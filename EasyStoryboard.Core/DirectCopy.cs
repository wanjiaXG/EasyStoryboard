using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core
{
    public class CopyFile : ICopyFile
    {

        private Dictionary<string, int> dic = new Dictionary<string, int>();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public string GetFilePath(string outDirectory, string relativePath, string sourcePath)
        {
            if (!File.Exists(sourcePath)) throw new FileNotFoundException($"File '{sourcePath}' not found.");

            string newPath = outDirectory + "\\" + relativePath;

            if (!File.Exists(newPath))
            {
                FileInfo fileInfo = new FileInfo(newPath);
                if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();
                File.Copy(sourcePath, newPath);
            }
            else
            {
                int num = 0;
                if (dic.ContainsKey(newPath))
                {
                    num = dic[newPath] + 1;
                    dic[newPath] = num;
                }
                else
                {
                    dic.Add(newPath, num);
                }


                string oldMd5 = Commons.CommonUtil.GetFileMD5Hash(newPath);
                string newMd5 = Commons.CommonUtil.GetFileMD5Hash(sourcePath);
                if (!oldMd5.Equals(newMd5))
                {
                    FileInfo info = new FileInfo(newPath);
                    newPath = info.DirectoryName + "\\" + info.Name.Replace(info.Extension, "");
                    if (!string.IsNullOrWhiteSpace(info.Extension) && newPath.EndsWith("."))
                    {
                        newPath = newPath.Substring(0, newPath.Length - 1);
                    }
                    newPath = newPath + "_" + num + info.Extension;
                    File.Copy(sourcePath, newPath);

                    relativePath = newPath.Replace(sourcePath.Replace(relativePath,""), "");
                    while (relativePath.StartsWith("\\"))
                    {
                        relativePath = relativePath.Substring(1);
                    }
                }
            }

            return relativePath;
        }
    }
}
