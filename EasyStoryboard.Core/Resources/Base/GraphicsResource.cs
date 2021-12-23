using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Resources.Enums;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class GraphicsResource : Resource
    {
        protected GraphicsResource(
            ResoureLayerType type,
            ResourceType resourceType) : base(type, resourceType) { }

        public GraphicsResource(string filePath, 
            ResoureLayerType resoureLayerType, 
            ResourceType resourceType) : base(filePath, resoureLayerType, resourceType) { }


        public GraphicsResource(string baseDirectory, 
            string relativePath, 
            ResoureLayerType resoureLayerType, 
            ResourceType resourceType) : base(baseDirectory, relativePath, resoureLayerType, resourceType) { }

        public Location Location { set; get; } = new Location(0, 0);

        public int X 
        {
            set
            {
                Location.X = value;
            }
            get
            {
                return Location.X;
            }
        }

        public int Y
        {
            set
            {
                Location.Y = value;
            }
            get
            {
                return Location.Y;
            }
        }

    }
}
