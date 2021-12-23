using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;

namespace EasyStoryboard.Core
{
    public class Background : StaticResource
    {
        public Background() : base(ResoureLayerType.BackgroundOrVideo, ResourceType.Background) { }

        public Background(string filePath) :base(filePath, ResoureLayerType.BackgroundOrVideo, ResourceType.Background) { }

        public Background(string baseDirectory,
            string relativePath) : base(baseDirectory, relativePath, ResoureLayerType.BackgroundOrVideo, ResourceType.Background) { }

        public override string GetCode(Options ops)
        {
            ops.Optimize = true;
            return base.GetCode(ops);
        }

    }
}
