using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Resources.Enums;
using System.IO;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class Resource
    {
        public string FilePath { set; get; }

        public ResourceType ResourceType { private set; get; }

        internal Resource(ResourceType type)
        {
            ResourceType = type;
        }

        public Resource() { }

        public Resource(string filePath) 
        {
            FilePath = filePath;
        }

    }
}
