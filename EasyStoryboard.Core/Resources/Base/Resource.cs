using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Resources.Enums;
using System.IO;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class Resource
    {
        #region StoryboardLayerType
        internal StoryboardLayerType StoryboardLayerType { set; get; }

        internal Resource SetStoryboardLayerType(StoryboardLayerType type)
        {
            StoryboardLayerType = type;
            return this;
        }
        #endregion

        internal Resource(ResourceType type, string filePath)
        {
            ResourceType = type;
            FilePath = filePath;
        }

        public string FilePath { set; get; }

        public ResourceType ResourceType { private set; get; }

        public Resource() { }

        public abstract void Load(string code);

        public abstract void 
    }
}
