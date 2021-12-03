using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;

namespace EasyStoryboard.Core
{
    public class Background : StaticResource
    {
        public Background() : base(ResourceType.Background) { }

        public override string GetCode(bool optimize)
        {
            return base.GetCode(true);
        }
    }
}
