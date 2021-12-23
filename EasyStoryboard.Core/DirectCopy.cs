﻿using System;
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

        private Dictionary<string, string> files = new Dictionary<string, string>();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public string GetFilePath(string outDirectory, string relativePath, string sourcePath)
        {
            outDirectory = new DirectoryInfo(outDirectory).FullName;

            relativePath = new FileInfo(outDirectory + "\\" + relativePath).FullName.Replace(outDirectory, "");

            sourcePath = new FileInfo(sourcePath).FullName;

            if (!File.Exists(sourcePath)) throw new FileNotFoundException($"File '{sourcePath}' not found.");

            string currentMd5 = Commons.CommonUtil.GetFileMD5Hash(sourcePath);

            if (files.ContainsKey(currentMd5))
            {
                relativePath = files[currentMd5];
            }
            else
            {
                string newPath = outDirectory + "\\" + relativePath;

                if (!File.Exists(newPath))
                {
                    FileInfo fileInfo = new FileInfo(newPath);
                    if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();
                    File.Copy(sourcePath, newPath);
                    files.Add(currentMd5, relativePath);
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

                    if (!oldMd5.Equals(currentMd5))
                    {
                        FileInfo info = new FileInfo(newPath);
                        newPath = info.DirectoryName + "\\" + info.Name.Replace(info.Extension, "");
                        newPath = newPath + "_" + num + info.Extension;
                        File.Copy(sourcePath, newPath);
                        relativePath = newPath.Replace(outDirectory, "");
                        files.Add(currentMd5, relativePath);
                    }
                }
            }


            while (relativePath.StartsWith("\\"))
            {
                relativePath = relativePath.Substring(1);
            }

            return relativePath;
        }
    }
}
