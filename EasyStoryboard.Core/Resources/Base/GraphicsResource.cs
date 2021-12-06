using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Resources.Enums;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class GraphicsResource : Resource
    {
        public SBLocation Location { set; get; } = new SBLocation(0, 0);

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

        public GraphicsResource(ResourceType type) : base(type) { }
    
    }
}
