using EasyStoryboard.Core.Common;
using EasyStoryboard.Core.Resources.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class GraphicsResource : Resource
    {
        public SBLocation Location { set; get; } = new SBLocation(0, 0);

        public int X => Location.X;

        public int Y => Location.Y;

        public int Offset { set; get; }

        public GraphicsResource(ResourceType type) : base(type) { }
    
    }
}
