using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Resources.Enums;
using System;
using System.IO;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class Resource
    {
        public string AbsoluteFilePath 
        {
            set
            {
                if(value != null && File.Exists(value))
                {
                    FileInfo info = new FileInfo(value);
                    string path = info.FullName;
                    if (BaseDirectory != null &&
                    path.ToLower().StartsWith(BaseDirectory.ToLower()))
                    {
                        RelativePath = path.Substring(BaseDirectory.Length);
                    }
                    else
                    {
                        BaseDirectory = info.DirectoryName;
                        RelativePath = info.Name;
                    }
                }
            }
            get
            {
                return BaseDirectory == null || RelativePath == null?
                    null:
                    $"{BaseDirectory}\\{RelativePath}";
            }
        }

        private string _RelativePath;
        public string RelativePath 
        {
            set
            {
                if (value != null)
                {
                    while (value.Length > 0)
                    {
                        if (value.StartsWith("\\") || value.StartsWith("/"))
                        {
                            value = value.Substring(1, value.Length - 1);
                        }
                        else
                        {
                            break;
                        }
                    }
                    _RelativePath = value;
                }
                else
                {
                    _RelativePath = value;
                }

                
            }
            get
            {
                return _RelativePath;
            }
        }

        private string _BaseDirectory;
        public string BaseDirectory 
        {
            set
            {
                if (value != null)
                {
                    _BaseDirectory = new DirectoryInfo(value + "\\").FullName; ;
                }
            }
            get
            {
                return _BaseDirectory;
            }
        }

        public ResourceType ResourceType { protected set; get; }

        public ResoureLayerType ResoureLayerType { protected set; get; }

        internal Resource(string filePath)
        {
            AbsoluteFilePath = filePath;
            Init();
        }

        internal Resource(string baseDirectory, string relativePath)
        {
            BaseDirectory = baseDirectory;
            RelativePath = relativePath;
            Init();
        }

        public abstract void Init();

        public abstract void LoadCode(Storyboard sb, string code);

        public abstract string GetCode(Options ops);

    }
}
