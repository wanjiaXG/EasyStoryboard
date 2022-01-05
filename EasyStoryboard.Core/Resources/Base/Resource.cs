using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using static EasyStoryboard.Core.Util;

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

        public Resource(string filePath, 
            ResoureLayerType resoureLayerType, 
            ResourceType resourceType) : this(resoureLayerType, resourceType)
        {
            AbsoluteFilePath = filePath;
        }

        public Resource(string baseDirectory, 
            string relativePath, 
            ResoureLayerType resoureLayerType,
            ResourceType resourceType) : this(resoureLayerType, resourceType)
        {
            BaseDirectory = baseDirectory;
            RelativePath = relativePath;
        }

        public Resource(ResoureLayerType type, ResourceType resourceType) 
        {
            ResoureLayerType = type;
            ResourceType = resourceType;
        }

        public abstract void LoadCode(string baseDirectory, string code);

        public abstract string GetCode(Options ops);

        protected void CheckResourcType(string type)
        {
            if (!Enum.TryParse(type, out ResourceType resType) || !resType.Equals(ResourceType))
            {
                throw new ArgumentException($"ResourceType is not {ResourceType}.");
            }
        }

        protected void SetFileName(string baseDirectoty, string relativePath)
        {
            string fileName = baseDirectoty + "\\" + relativePath;
            if (File.Exists(fileName))
            {
                BaseDirectory = baseDirectoty;
                RelativePath = relativePath;
            }
            else
            {
                throw new FileNotFoundException($"File '{fileName}' not found.");
            }
        }

    }
}
