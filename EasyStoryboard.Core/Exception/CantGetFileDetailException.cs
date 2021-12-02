using System;
using System.IO;
using System.Runtime.Serialization;

namespace EasyStoryboard.Core.Exception
{
    [Serializable]
    internal class CantGetFileDetailException : IOException
    {
        public CantGetFileDetailException(string fileName) : base($"无法获取文件'{fileName}'的详细信息", -1) { }
    }
}