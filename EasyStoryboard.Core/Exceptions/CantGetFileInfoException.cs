using System;
using System.IO;
using System.Runtime.Serialization;

namespace EasyStoryboard.Core.Exceptions
{
    [Serializable]
    internal class CantGetFileInfoException : IOException
    {
        public CantGetFileInfoException(string fileName) : base($"无法获取文件'{fileName}'的详细信息", -1) { }
    }
}