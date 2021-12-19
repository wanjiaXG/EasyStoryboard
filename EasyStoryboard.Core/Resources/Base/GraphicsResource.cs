using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Resources.Enums;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class GraphicsResource : Resource
    {
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

        internal GraphicsResource(ResourceType type) : base(type) { }
    
    }
}
