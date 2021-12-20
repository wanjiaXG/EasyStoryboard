using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Resources.Enums;
using System.IO;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class Resource
    {
        public string FilePath { set; get; }

        public ResourceType ResourceType { private set; get; }

        internal ResoureLayerType ResoureLayerType { private set; get; }

        internal Resource SetStoryboardLayerType(ResoureLayerType type)
        {
            ResoureLayerType = type;
            return this;
        }

        internal Resource(ResourceType type, string filepath)
        {
            ResourceType = type;
            FilePath = filepath;
        }

        public abstract void LoadCode(Storyboard sb, string code);

        public abstract string GetCode(Storyboard sb, SaveOptions ops);

    }
}
