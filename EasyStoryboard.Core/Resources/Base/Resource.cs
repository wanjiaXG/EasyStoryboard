using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Resources.Enums;
using System.IO;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class Resource
    {
        public string FilePath { set; get; }

        public ResourceType ResourceType { private set; get; }

        public ResoureLayerType ResoureLayerType { set; get; }

        public Resource SetStoryboardLayerType(ResoureLayerType type)
        {
            ResoureLayerType = type;
            return this;
        }

        internal Resource(ResourceType type)
        {
            ResourceType = type;
        }

        public Resource() { }

        public Resource(string filePath) 
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"file '{filePath}' not found!", filePath);
            }
            FilePath = filePath;
        }

        public abstract void LoadCode(Storyboard storyboard, string code);

        public abstract string GetCode(Storyboard storyboard, SaveOptions options);

    }
}
