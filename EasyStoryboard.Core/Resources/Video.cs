using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;

namespace EasyStoryboard.Core.Resources
{
    public class Video : StaticResource
    {
        public Video() : base(ResoureLayerType.BackgroundOrVideo, ResourceType.Video) { }

        public Video(string filePath) : base(filePath, ResoureLayerType.BackgroundOrVideo, ResourceType.Video) { }

        public Video(string baseDirectory, string relativePath) : base(baseDirectory, relativePath, ResoureLayerType.BackgroundOrVideo, ResourceType.Video) { }

    }
}
